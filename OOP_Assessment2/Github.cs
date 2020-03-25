using System;

namespace OOP_Assessment2
{
    class Github
    {
        public bool Diff(string[] file1, string[] file2)
        {
            // Check if the files are the same length, if not then return false
            if (file1.Length == file2.Length)
            {
                // For each item in the file
                for (int i = 0; i < file1.Length; i++)
                {
                    // If the item in the first file is not equal to the second file, then return false
                    if (file1[i] != file2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
