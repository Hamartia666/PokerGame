using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerGame.Client.Forms.Controls
{
    public partial class ucPlayer : UserControl
    {
        //PlayerGUID
        Guid? _clientId = null;
        public bool IsFree { get { return _clientId == null; } }
        //Info o kartach
        public ucPlayer()
        {
            InitializeComponent();
        }

        public void SitPlayer(string name, Guid guid)
        {
            MethodInvoker invoker = new MethodInvoker(delegate
            {
                playerName.Text = name;
                _clientId = guid;
                cash_value.Text = "100";
            });
            this.Invoke(invoker);
        }
    }
}
