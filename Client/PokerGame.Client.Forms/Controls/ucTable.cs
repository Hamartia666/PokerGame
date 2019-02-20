using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokerGame.Common;

namespace PokerGame.Client.Forms.Controls
{
    public partial class ucTable : UserControl
    {
        public ucTable()
        {
            InitializeComponent();
        }

        public void AddCard(Card c)
        {
            ucCard card = new ucCard();
        }
    }
}
