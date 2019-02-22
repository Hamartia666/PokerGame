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
    public partial class ucPlayer : UserControl
    {
        //PlayerGUID
        public Guid? _clientId = null;
        public bool IsFree { get { return _clientId == null; } }
        public int Cash { get; private set; } = 100;
        public int Bid { get; private set; } = 0;
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
                cash_value.Text = Cash.ToString();
                Bid_value.Text = Bid.ToString();
            });
            this.Invoke(invoker);
        }

        public void UpdateName(string name)
        {
            MethodInvoker invoker = new MethodInvoker(delegate
            {
                playerName.Text = name;
            });
            this.Invoke(invoker);
        }

        public void UpdateCards(List<Card> cards)
        {
            ucCard1.SetCardValue(cards[0]);
            ucCard2.SetCardValue(cards[1]);
        }

        public void DisplayCards()
        {
            ucCard1.ShowValue = true;
            ucCard2.ShowValue = true;
        }

        public void UpdateBid(int bid)
        {
            MethodInvoker invoker = new MethodInvoker(delegate
            {
                if (bid == 0)
                {
                    Bid = 0;
                }
                else
                {
                    Cash -= Bid - bid;
                    Bid = bid;                    
                }
                Bid_value.Text = Bid.ToString();
                cash_value.Text = Cash.ToString();
            });
            this.Invoke(invoker);
        }

    }
}
