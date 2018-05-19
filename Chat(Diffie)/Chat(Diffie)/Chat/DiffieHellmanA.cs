using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace A
{
    class DiffieHellmanA
    {
        public byte[] alicePublicKey;
        public byte[] aliceKey;

        public byte[] generatePublicKey()
        {
           
            using (ECDiffieHellmanCng alice = new ECDiffieHellmanCng())//phát sinh key 
            {
                alice.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                alice.HashAlgorithm = CngAlgorithm.Sha256;
                alicePublicKey = alice.PublicKey.ToByteArray();
                byte[] a = alicePublicKey;
                return a;
            }

        }
        public byte[] secretKey(byte[] bobPublicKey)
        {
           
            using (ECDiffieHellmanCng alice = new ECDiffieHellmanCng())
            {
                
                CngKey k = CngKey.Import(bobPublicKey, CngKeyBlobFormat.EccPublicBlob);
                aliceKey = alice.DeriveKeyMaterial(k);
                byte[] a = aliceKey;
                return a;
            }
            
        }
        
        

        
        

    }
}
