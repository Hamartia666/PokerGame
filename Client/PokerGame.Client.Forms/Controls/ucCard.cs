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
    public partial class ucCard : UserControl
    {
        private Card _card;
        private bool _showValue = false;
        public bool ShowValue { get { return _showValue; } set { _showValue = value; ShowCardValue(); } }

        public void SetCardValue(Card card)
        {
            _card = card;            
        }

        private void ShowCardValue()
        {
            if (_showValue)
            {
                MethodInvoker invoker = new MethodInvoker(delegate
                {
                    Value.Text = _card.Value.ToString();
                    Suit.Text = _card.Suit.ToString();

                });
                this.Invoke(invoker);
            }
        }

        public ucCard()
        {
            InitializeComponent();
        }
    }
}
