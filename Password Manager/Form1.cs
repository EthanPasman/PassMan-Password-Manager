using System.Security.Cryptography;
using System.Text;

namespace Password_Manager
{
    public partial class LoginForm : Form
    {
        private const int iter = 100000;
        private byte[] salt = new byte[128];
        private bool isRegistered;
        private bool verify;
        private string? nextLine;
        private string path;
        private string? temp;
        private List<string> linesToEncrypt;
        private List<string> plaintext;
        
        public LoginForm()
        {
            InitializeComponent();

            isRegistered = false;
            verify = false;
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Pwm";
            linesToEncrypt = new List<string>();
            plaintext = new List<string>();
        }

        private void SecBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" +
                "This password manager uses multiple security measures to keep your sensitive information safe.\n" +
                "\nAll passwords are stored locally in encrypted files, using the AES-256 (Advanced Encryption Standard) encryption algorithm.\n" +
                "These files will look like random garbled text to anyone snooping through local files on your device.\n" +
                "This encryption goes through 100,000 iterations, making it extremely difficult for a hacker to brute-force the encryption.\n" +
                "In order to access your passwords from the password manager itself, you must log in using a master password.\n" +
                "This master password is never stored anywhere, as it is hashed using the PBKDF2 (Password-Based Key Derivation Function 2) algorithm.\n" +
                "This hash is a one-way process and it is impossible for hackers to get your master password from this hash value due to salting and key-stretching.\n" +
                "Your login information is also stored locally in an encrypted file.\n" +
                "There is no Internet connection used, data sent or received from anywhere, or chance for hackers to intercept said data.\n" +
                "\nIt is strongly recommended to make your master password very long and hard to guess, and make all of your other passwords randomly generated.\n" +
                "This password manager comes with a random password generator for you to use to make yourself more secure.\n" +
                "These generated passwords use crpytographically secure random values instead of pseudorandom values commonly used in many programs.\n" +
                "", "Security Overview", MessageBoxButtons.OK);
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(path + "\\" + UserTextBox.Text + ".txt"))
            {
                using (StreamReader auth = new StreamReader(path + "\\pwmlogin.txt"))
                {
                    while ((nextLine = auth.ReadLine()) != null)
                    {
                        if (nextLine == Hashed(UserTextBox.Text, UserTextBox.Text))
                        {
                            if (auth.ReadLine() == Hashed(PassTextBox.Text, UserTextBox.Text))
                            {
                                verify = true;
                            }
                        }
                    }
                }
                nextLine = null;

                if (verify)
                {
                    //Decrypt user file
                    Decrypt(path + "\\" + UserTextBox.Text + ".txt", PassTextBox.Text);

                    //Switch from LoginForm to MainForm
                    MainForm form = new MainForm(UserTextBox.Text);
                    form.Location = this.Location;
                    form.StartPosition = FormStartPosition.Manual;

                    //Closing MainForm re-encrypts user file, closes LoginForm
                    form.FormClosing += delegate { OnClose(path + "\\" + UserTextBox.Text + ".txt", PassTextBox.Text); };
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username or password incorrect.", "Login failed");
                    UserTextBox.Text = "";
                    PassTextBox.Text = "";
                }
            } else
            {
                MessageBox.Show("Username or password incorrect.", "Login failed");
                UserTextBox.Text = "";
                PassTextBox.Text = "";
            }
        }

        private void RegBtn_Click(object sender, EventArgs e)
        {
            //On first use, create users file to store list of users registered on this device
            Directory.CreateDirectory(path);
            FileStream newfile = new FileStream(path + "\\pwmlogin.txt", FileMode.OpenOrCreate);
            newfile.Close();

            //Check if username is already registered
            isRegistered = false;
            if (new FileInfo(path + "\\pwmlogin.txt").Length > 0)
            {
                if (File.ReadAllText(path + "\\pwmlogin.txt").Contains(Hashed(UserTextBox.Text, UserTextBox.Text)))
                {
                    isRegistered = true;
                }
            }

            //Check if username and password are valid entries
            if (string.IsNullOrEmpty(UserTextBox.Text) || string.IsNullOrEmpty(PassTextBox.Text))
            {
                MessageBox.Show("Please enter new username and password in the above fields.", "Registration failed");
            }
            else if (isRegistered)
            {
                MessageBox.Show("Username entered is already registered.", "Registration failed");
            }
            else if (UserTextBox.Text.Length > 127 || PassTextBox.Text.Length > 127 || UserTextBox.Text.Length < 8 || PassTextBox.Text.Length < 8)
            {
                MessageBox.Show("Username and password must be between 8 and 128 characters.", "Registration failed");
            }
            else
            {
                FileStream userFile = new FileStream(path + "\\" + UserTextBox.Text + ".txt", FileMode.OpenOrCreate);
                userFile.Close();

                FileStream pwmusers = File.Open(path + "\\pwmlogin.txt", FileMode.Append);
                StreamWriter userWriter = new StreamWriter(pwmusers);

                userWriter.WriteLine(Hashed(UserTextBox.Text, UserTextBox.Text));
                userWriter.WriteLine(Hashed(PassTextBox.Text, UserTextBox.Text));

                userWriter.Close();
                pwmusers.Close();
            }
            UserTextBox.Text = "";
            PassTextBox.Text = "";
        }

        private void Encrypt(string plainTextFile, string pw)
        {
            if (plainTextFile == null || pw == null)
            {
                MessageBox.Show("Encryption failed.", "Error");
                return;
            }
            
            //Encryption method used is AES-256, Advanced Encryption Standard
            Aes AES = Aes.Create();
            AES.KeySize = 256;
            AES.BlockSize = 128;

            //Key is based on password byte array and username byte array
            var key = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(pw), salt, iter);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            linesToEncrypt.Clear();
            StreamReader lineReader = new StreamReader(plainTextFile);
            while ((temp = lineReader.ReadLine()) != null)
            {
                linesToEncrypt.Add(temp);
            }
            lineReader.Close();

            //Overwrite user file with new encrypted data
            FileStream replace = new FileStream(plainTextFile, FileMode.Create);
            CryptoStream cryptoStream = new CryptoStream(replace, AES.CreateEncryptor(), CryptoStreamMode.Write);
            StreamWriter newData = new StreamWriter(cryptoStream);
            int i;
            for (i = 0; i < linesToEncrypt.Count; i++)
            {
                newData.WriteLine(linesToEncrypt[i]);
            }

            newData.Close();
            cryptoStream.Close();
            replace.Close();
        }

        private void Decrypt(string EncryptedFile, string pw)
        {
            if (EncryptedFile == null || pw == null)
            {
                MessageBox.Show("Decryption failed.", "Error");
                return;
            }

            Aes AES = Aes.Create();
            AES.KeySize = 256;
            AES.BlockSize = 128;

            var key = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(pw), salt, iter);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            plaintext.Clear();
            FileStream replace = new FileStream(EncryptedFile, FileMode.Open);
            CryptoStream cryptoStream = new CryptoStream(replace, AES.CreateDecryptor(), CryptoStreamMode.Read);
            StreamReader newData = new StreamReader(cryptoStream);
            plaintext.Add(newData.ReadToEnd());

            newData.Close();
            cryptoStream.Close();
            replace.Close();

            File.WriteAllLines(EncryptedFile, plaintext);
        }

        private string Hashed(string toHash, string user)
        {
            if (String.IsNullOrEmpty(toHash))
            {
                return "";
            }
            //Salt is username converted to byte array
            //Unique but consistent salt for each user
            Array.Clear(salt, 0, salt.Length);
            Encoding.UTF8.GetBytes(user).CopyTo(salt, 0);

            //PBKDF2 (Password-based key derivation function 2) hashing algorithm used
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(toHash, salt, iter);
            return Encoding.UTF8.GetString(pbkdf2.GetBytes(128));
        }

        private void OnClose(string f, string p)
        {
            //Re-encrypt user file
            Encrypt(f, p);

            //Close LoginForm
            this.Close();
        }
    }
}