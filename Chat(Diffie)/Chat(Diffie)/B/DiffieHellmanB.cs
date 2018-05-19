using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace B
{
    class DiffieHellmanB
    {
        public byte[] bobPublicKey;
        public byte[] bobKey;
        public byte[] generatePublicKey()
        {
    
            using (ECDiffieHellmanCng bob = new ECDiffieHellmanCng())
            {
               
                bob.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                bob.HashAlgorithm = CngAlgorithm.Sha256;
                bobPublicKey = bob.PublicKey.ToByteArray();
                byte[] a = bobPublicKey;
                return a;
            }
           
        }

        public byte[] secretKey(byte[] alicePublicKey)
        {
           
            using (ECDiffieHellmanCng bob = new ECDiffieHellmanCng())
            {
               
                CngKey k = CngKey.Import(alicePublicKey, CngKeyBlobFormat.EccPublicBlob);
                bobKey = bob.DeriveKeyMaterial(k);
                byte[] a = bobKey;
                return a;
            }
          
        }
        
    }
}
