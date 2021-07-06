using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPServer.UDPServer
{
    public class LargeMessage
    {
        private List<byte[]> snippets = new List<byte[]>();
        private List<int> indices = new List<int>();
        private int amntPckgs;

        private int complByteSize = 0;

        public LargeMessage(int largeID, int amountPackages)
        {
            amntPckgs = amountPackages;
            LargeID = largeID;
        }

        public int LargeID
        {
            get; protected set;
        }

        public void AddSnippet(int index, byte[] data)
        {
            bool hasAlready = false;
            for (int i = 0; i < indices.Count; i++)
            {
                if (indices[i] == index)
                {
                    hasAlready = true;
                    break;
                }
            }

            if (!hasAlready)
            {
                complByteSize += data.Length;
                indices.Add(index);
                snippets.Add(data);
            }
        }

        public bool IsComplete
        {
            get
            {
                return indices.Count >= amntPckgs;
            }
        }


        public byte[] CompleteMessage
        {
            get
            {
                int runningIndex = 0;
                byte[] compl = new byte[complByteSize];

                for (int i = 0; i < indices.Count; i++)
                {
                    for (int j = 0; j < indices.Count; j++)
                    {
                        int lookIndex = (j + i) % indices.Count;

                        if (indices[lookIndex] == i)
                        {
                            for (int k = 0; k < snippets[lookIndex].Length; k++)
                            {
                                compl[runningIndex + k] = snippets[lookIndex][k];
                            }

                            runningIndex += snippets[lookIndex].Length;

                            break;
                        }
                    }
                }

                return compl;
            }
        }
    }
}
