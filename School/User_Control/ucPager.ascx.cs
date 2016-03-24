using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School.User_Control
{
    public partial class ucPager : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPager_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            if (btn.ID == "btnPagerPrev")
            {
                Pager.CurrentIndex = (((Pager.CurrentIndex - 1) != 0)) ? Pager.CurrentIndex - 1 : 1;
            }
            if (btn.ID == "btnPagerFirst")
            {
                Pager.CurrentIndex = 1;
            }
            if (btn.ID == "btnPagerLast")
            {
                Pager.CurrentIndex = Pager.ItemCount;
            }
            if (btn.ID == "btnPagerNext")
            {
                Pager.CurrentIndex = (((Pager.CurrentIndex + 1) <= Pager.ItemCount)) ? Pager.CurrentIndex + 1 : Pager.ItemCount;
            }
            OnPagerClick(sender, e);
        }

        public event EventHandler PagerClick;
        protected virtual void OnPagerClick(object sender, EventArgs e)
        {
            if (PagerClick != null)
            {
                PagerClick(this, e);
            }
        }
        public string Information
        {
            get
            {
                return btnPagerinfo.Text;
            }
            set
            {
                btnPagerinfo.Text = value;
            }
        }
    }
}