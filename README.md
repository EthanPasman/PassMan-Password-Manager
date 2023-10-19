# Password Manager
A local password manager with encryption, hashed login, and secure random password generator.

## Security overview:
This password manager uses multiple security measures to keep your sensitive information safe.
All passwords are stored locally in encrypted files, using the AES-256 (Advanced Encryption Standard) encryption algorithm. These files will look like random garbled text to anyone snooping through local files on your device. This encryption goes through 100,000 iterations, making it extremely difficult for a hacker to brute-force the encryption.
In order to access your passwords from the password manager itself, you must log in using a master password. This master password is never stored anywhere, as it is hashed using the PBKDF2 (Password-Based Key Derivation Function 2) algorithm. This hash is a one-way process and it is impossible for hackers to get your master password from this hash value due to salting and key-stretching.
Your login information is also stored locally in an encrypted file. There is no Internet connection used, data sent or received from anywhere, or chance for hackers to intercept said data.

It is strongly recommended to make your master password very long and hard to guess, and make all of your other passwords randomly generated. This password manager comes with a random password generator for you to use to make yourself more secure. These generated passwords use crpytographically secure random values instead of pseudorandom values commonly used in many programs.
