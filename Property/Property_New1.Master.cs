﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Property_cls;
using System.Data.SqlClient;


namespace Property
{
    public partial class Property_New1 : System.Web.UI.MasterPage
    {
        #region Global

        cls_Property clsobj = new cls_Property();

        #endregion Global
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMenusList();
                SiteSetting();
            }
        }
        private void BindMenusList()
        {
            StringBuilder StrMenu = new StringBuilder();
            DataTable dt = new DataTable();
            DataTable dtSubmenu = new DataTable();
            dt = clsobj.GetMenuList();



            if (dt.Rows.Count > 0)
            {
                string PageName = dt.Rows[0]["PageName"].ToString();
                StrMenu.Append("<a class='toggleMenu' href='#'></a>");
                StrMenu.Append("<ul class='nav'>");
                StrMenu.Append("<li class='test' style='background:none;'><a href='../Home.aspx' title='Home' class='active'>Home</a></li>");

                StrMenu.Append("<li><a href=#>Seller </a>");//</li>
                StrMenu.Append("<ul>");
                StrMenu.Append("<li><a href='SellingyourHouse.aspx' title='Selling your House'>Selling your House</ a> </li>");
                StrMenu.Append("<li><a href='RenovatingResale.aspx' title='Renovating Resale'>Renovating Resale</a> </li>");
                StrMenu.Append("<li><a href='CommonSellingMistakes.aspx' title='Common Selling Mistakes'>Common Selling Mistakes</a> </li>");

                StrMenu.Append("</ul>");
                clsobj.PageID = Convert.ToInt32(dt.Rows[1]["ID"]);
                dtSubmenu = clsobj.GetSubMenuBy_PageID();
                StrMenu.Append("<li><a href=#>" + dt.Rows[1]["PageName"] + "</a>");//</li>
                StrMenu.Append("<ul>");
                for (int j = 0; j < dtSubmenu.Rows.Count; j++)
                {
                    StrMenu.Append("<li><a href='../StaticPages.aspx?PageID=" + dtSubmenu.Rows[j]["id"] + "' title='" + dtSubmenu.Rows[j]["PageName"] + "'>" + dtSubmenu.Rows[j]["PageName"] + "</a> </li>");
                }
                StrMenu.Append("</ul>");
                StrMenu.Append("</li>");
                //StrMenu.Append("<li class='test' style='background:none;'><a href='Admin/Adminlogin.aspx' title='Login'>Login</a></li>");
                StrMenu.Append("<li><a href=#>Calculators </a>");//</li>
                StrMenu.Append("<ul>");
                StrMenu.Append("<li><a href='Calculator.aspx' title='Land Transfer Tax Calculator'>Land Transfer Tax Calculator</ a> </li>");
                //StrMenu.Append("<li><a href='MortgageCalculator.aspx' title='Mortgage Loan calculator'>Mortgage Loan calculator</a> </li>");
                StrMenu.Append("<li><a href='Mortgage_Affordability_Calculator.aspx' title='Mortgage payment calculator'>Mortgage Payment calculator</a> </li>");
                StrMenu.Append("<li><a href='PremiumCalculator.aspx' title='CMHC Premium calculator'>CMHC Premium calculator</a> </li>");
                StrMenu.Append("</ul>");

                StrMenu.Append("</li>");
                //StrMenu.Append("<li>");
                //StrMenu.Append("<a href='../Calculators.aspx' title='Calculators'>Calculators</a>");
                //StrMenu.Append("</li>");
                StrMenu.Append("<li>");
                //StrMenu.Append("<a href='../RealEstateNews.aspx' title='Real Estate News'>Real Estate News</a>");
                StrMenu.Append("</li>");
                StrMenu.Append("<li>");
                StrMenu.Append("<a href='../DreamHouse.aspx' title='Pre-Constructions'>Pre-Constructions</a>");
                StrMenu.Append("</li>");
                StrMenu.Append("<li class='test' style='background:none;'><a href='Home_Worth.aspx' title='Free Market Evaluation'>Free Market Evaluation</a></li>");
                StrMenu.Append("<li class='test' style='background:none;'><a href='VirtualTour.aspx' title='Virtual Tour'>Virtual Tour</a></li>");
                //StrMenu.Append("<li class='test' style='background:none;'><a style='border:none' href='View_Testimonials.aspx' title='Testimonials'>Testimonials</a></li>");
                StrMenu.Append("<li class='test' style='background:none;'><a style='border:none' href='ContactUs.aspx' title='Contact Us'>Contact Us</a></li>");
               
                //StrMenu.Append("<li class='test' style='background:none;'><a href='admin/adminlogin.aspx' title='Login'>Login</a></li>");
                StrMenu.Append("</ul>");


            }


            dynamicmenus.Text = StrMenu.ToString();

        }

        protected void SiteSetting()
        {
            try
            {
                DataTable dt = clsobj.GetSiteSettings();
                DataTable dt1 = clsobj.GetUserInfo();
                if (dt.Rows.Count > 0)
                {
                   // lblemailid2.Text = Convert.ToString(dt.Rows[0]["Email2"]);
                    siteTitle.Text = Convert.ToString(dt.Rows[0]["Title"]);
                    lblemail.Text = Convert.ToString(dt.Rows[0]["Email"]);
                    lblBrkrOneName.Text = Convert.ToString(dt1.Rows[0]["FirstName"]) + " " + Convert.ToString(dt1.Rows[0]["LastName"]);
                    //lblphn.Text = Convert.ToString(dt.Rows[0]["Mobile"]);
                    lblphone.Text = Convert.ToString(dt.Rows[0]["Mobile"]);
                    byte[] favimage = (byte[])dt.Rows[0]["Favicon.ico"];
                    if (favimage.Length > 0)
                    {
                        Session["MyFavicon"] = favimage;
                        favicon.Visible = true;
                        favicon.Href = "~/ShowFavicon.aspx";
                    }
                    else
                    {
                        favicon.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}