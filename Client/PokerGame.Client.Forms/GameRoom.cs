using PokerGame.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerGame.Client.Forms
{
    public partial class GameRoom : Form, IProcessMessage
    {
        Guid RoomId;
        private MainForm _parent;

        public GameRoom(MainForm parent)
        {
            InitializeComponent();
            _parent = parent;
            
        }

        public void ProcessMessage(IMessage message)
        {

        }

        void Send()
        {
            
        }
    }
}
