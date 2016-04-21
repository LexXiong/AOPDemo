using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemo.Main.Services
{
    public class StorageNode : IStorageNode
    {
        private string _name;

        public StorageNode(string name)
        {
            _name = name;
        }

        public bool IsDead { get; set; }

        public void Save(string message)
        {
            Console.WriteLine(string.Format("\"{0}\" was saved to {1}", message, _name));
        }
    }
}
