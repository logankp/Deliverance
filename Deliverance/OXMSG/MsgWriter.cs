using Deliverance.OXMSG.Properties;
using OpenMcdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverance.OXMSG
{
    /// <summary>
    /// This class creates a .msg file
    /// </summary>
    class MsgWriter
    {
        CompoundFile cf = new CompoundFile();

        public void Create(Message file)
        {
            CreateSkeleton();

        }

        private void CreateSkeleton()
        {
            cf.RootStorage.AddStream(PropertyStream.STREAM_NAME);
            cf.RootStorage.AddStorage(NamedPropertyParser.STORAGE_NAME);
        }
    }
}
