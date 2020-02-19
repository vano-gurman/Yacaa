using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Yacaa.Shared.Encryption
{
    public static class SecureStringExtensions
    {
        private const int EntropyBytes = 32;
        
        /// <summary>
        /// Converts a secured string to an unsecured string
        /// </summary>
        public static string ToUnsecuredString(this SecureString secureString)
        {
            // copy&paste from the internal System.Net.UnsafeNclNativeMethods
            var bstrPtr = IntPtr.Zero;
            if (secureString == null || secureString.Length == 0) return string.Empty;
            try
            {
                bstrPtr = Marshal.SecureStringToBSTR(secureString);
                return Marshal.PtrToStringBSTR(bstrPtr);
            }
            finally
            {
                if (bstrPtr != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(bstrPtr);
            }
        }

        /// <summary>
        /// Copies the existing instance of a secure string into the destination, clearing the destination beforehand
        /// </summary>
        public static void CopyInto(this SecureString source, SecureString destination)
        {
            destination.Clear();
            foreach (var chr in source.ToUnsecuredString())
            {
                destination.AppendChar(chr);
            }
        }

        /// <summary>
        /// Converts an unsecured string to a secured string
        /// </summary>
        public static SecureString ToSecuredString(this string plainString)
        {
            if (string.IsNullOrEmpty(plainString))
                return new SecureString();

            var secure = new SecureString();
            foreach (var c in plainString)
                secure.AppendChar(c);
            
            return secure;
        }

        public static string EncryptString(this SecureString secureString)
        {
            var entropy = GenerateRandomEntropy();
            var encryptedData = ProtectedData.Protect(
                Encoding.Unicode.GetBytes(secureString.ToUnsecuredString()),
                entropy,
                DataProtectionScope.CurrentUser);
            
            return Convert.ToBase64String(entropy.Concat(encryptedData).ToArray());
        }

        public static SecureString DecryptString(this string encryptedData)
        {
            try
            {
                var encryptedDataWithEntropy = Convert.FromBase64String(encryptedData);
                var decryptedData = ProtectedData.Unprotect(
                    encryptedDataWithEntropy.Skip(EntropyBytes).Take(encryptedDataWithEntropy.Length - EntropyBytes).ToArray(), // data
                    encryptedDataWithEntropy.Take(EntropyBytes).ToArray(), // entropy
                    DataProtectionScope.CurrentUser);
                return Encoding.Unicode.GetString(decryptedData).ToSecuredString();
            }
            catch
            {
                return new SecureString();
            }
        }
        
        private static byte[] GenerateRandomEntropy()
        {
            var randomBytes = new byte[EntropyBytes]; // 32 Bytes will give us 256 bits
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }
}