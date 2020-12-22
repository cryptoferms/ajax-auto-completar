using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.VisualBasic;
namespace ajax_autocomplete
{
  //public class ClickOnceButton : System.Web.UI.WebControls.WebControl, IPostBackEventHandler
  //  {
  //      public event EventHandler Click;
  //      public event System.Web.UI.WebControls.CommandEventHandler Command;

  //      private const string OnceClickBtnName = "__onceClickBtn";

  //      [Browsable(true)]
  //      [Category("Behavior")]
  //      public bool DisableScreen
  //      {
  //          get
  //          {
  //              object o = base.ViewState["DisableScreen"];
  //              return Interaction.IIf(Information.IsNothing(o), true, (bool)o);
  //          }
  //          set
  //          {
  //              base.ViewState["DisableScreen"] = Value;
  //          }
  //      }

  //      [Browsable(true)]
  //      [Category("Behavior")]
  //      public bool DisableAfterClick
  //      {
  //          get
  //          {
  //              object o = base.ViewState["DisableAfterClick"];
  //              return Interaction.IIf(Information.IsNothing(o), false, (bool)o);
  //          }
  //          set
  //          {
  //              base.ViewState["DisableAfterClick"] = Value;
  //          }
  //      }

  //      [Browsable(true)]
  //      [Category("Behavior")]
  //      public string CommandName
  //      {
  //          get
  //          {
  //              object o = base.ViewState["CommandName"];
  //              return Interaction.IIf(Information.IsNothing(o), string.Empty, (string)o);
  //          }
  //          set
  //          {
  //              base.ViewState["CommandName"] = Value;
  //          }
  //      }

  //      [Browsable(true)]
  //      [Category("Behavior")]
  //      public string CommandArgument
  //      {
  //          get
  //          {
  //              object o = base.ViewState["CommandArgument"];
  //              return Interaction.IIf(Information.IsNothing(o), string.Empty, (string)o);
  //          }
  //          set
  //          {
  //              base.ViewState["CommandArgument"] = Value;
  //          }
  //      }

  //      [Browsable(true)]
  //      [Category("Appearance")]
  //      public string DisabledText
  //      {
  //          get
  //          {
  //              object o = base.ViewState["DisabledText"];
  //              return Interaction.IIf(Information.IsNothing(o), string.Empty, (string)o);
  //          }
  //          set
  //          {
  //              base.ViewState["DisabledText"] = Value;
  //          }
  //      }

  //      [Browsable(true)]
  //      [Category("Appearance")]
  //      public string Text
  //      {
  //          get
  //          {
  //              object o = base.ViewState["Text"];
  //              return Interaction.IIf(Information.IsNothing(o), "Button", (string)o);
  //          }
  //          set
  //          {
  //              base.ViewState["Text"] = Value;
  //          }
  //      }

  //      [Browsable(true)]
  //      [Category("Behavior")]
  //      public bool CausesValidation
  //      {
  //          get
  //          {
  //              object o = base.ViewState["CausesValidation"];
  //              return Interaction.IIf(Information.IsNothing(o), true, (bool)o);
  //          }
  //          set
  //          {
  //              base.ViewState["CausesValidation"] = Value;
  //          }
  //      }

  //      public ClickOnceButton() : base(HtmlTextWriterTag.Input)
  //      {
  //      }

  //      [Browsable(false)]
  //      internal string GetClientValidateEvent
  //      {
  //          get
  //          {
  //              return "if (typeof(Page_ClientValidate) == 'function') Page_ClientValidate(); ";
  //          }
  //      }

  //      [Browsable(false)]
  //      internal string GetClickOnceClientValidateEvent
  //      {
  //          get
  //          {
  //              return "if (typeof(Page_ClientValidate) == 'function') { if(Page_ClientValidate()) { " + GetOnceClickJavascript + " }} else { " + GetOnceClickJavascript + " }";
  //          }
  //      }

  //      [Browsable(false)]
  //      internal string GetOnceClickJavascript
  //      {
  //          get
  //          {
  //              string strJavascript = "document.getElementsByName('" + this.OnceClickBtnName + "').item(0).setAttribute('name'," + "this.getAttribute('name')); this.disabled = true; " + Interaction.IIf(DisabledText == string.Empty, string.Empty, "this.value = '" + DisabledText + "';") + "this.form.submit();";

  //              // Pega o User Agent para ver se é FIREFOX.
  //              // O FF sempre dispara o evento onsubmit do FORM que já tem a função de Loading
  //              string strUserAgent = string.Empty;
  //              try
  //              {
  //                  strUserAgent = System.Web.HttpContext.Current.Request.UserAgent.ToUpper();
  //              }
  //              catch (Exception ex)
  //              {
  //              }

  //              if (this.DisableScreen && strUserAgent.IndexOf("FIREFOX") == -1)
  //                  strJavascript += "setTimeout('Splash();',50);";

  //              return strJavascript;
  //          }
  //      }

  //      protected override void RenderContents(HtmlTextWriter writer)
  //      {
  //      }

  //      protected override void AddAttributesToRender(HtmlTextWriter writer)
  //      {
  //          string strOnClick;

  //          if (Information.IsNothing(base.Page))
  //              base.Page.VerifyRenderingInServerForm(this);

  //          writer.AddAttribute(HtmlTextWriterAttribute.Type, "submit");
  //          writer.AddAttribute(HtmlTextWriterAttribute.Name, base.UniqueID);
  //          writer.AddAttribute(HtmlTextWriterAttribute.Value, this.Text);

  //          if (!Information.IsNothing(base.Page) & this.CausesValidation & base.Page.Validators.Count > 0)
  //          {
  //              if (this.DisableAfterClick)
  //                  strOnClick = this.GetClickOnceClientValidateEvent();
  //              else
  //                  strOnClick = this.GetClientValidateEvent();

  //              if (base.Attributes.Count > 0 & !Information.IsNothing(base.Attributes["onclick"]))
  //              {
  //                  strOnClick = string.Concat(base.Attributes["onclick"], strOnClick);
  //                  base.Attributes.Remove("onclick");
  //              }

  //              writer.AddAttribute("language", "javascript");
  //              writer.AddAttribute(HtmlTextWriterAttribute.Onclick, strOnClick);
  //          }
  //          else if (DisableAfterClick == true)
  //          {
  //              strOnClick = GetOnceClickJavascript();

  //              if (base.Attributes.Count > 0 & !Information.IsNothing(base.Attributes["onclick"]))
  //              {
  //                  strOnClick = string.Concat(base.Attributes["onclick"], strOnClick);
  //                  base.Attributes.Remove("onclick");
  //              }

  //              writer.AddAttribute("language", "javascript");
  //              writer.AddAttribute(HtmlTextWriterAttribute.Onclick, strOnClick);
  //          }

  //          base.AddAttributesToRender(writer);
  //      }

  //      protected override void OnInit(EventArgs e)
  //      {
  //          if (this.DisableAfterClick & !this.IsHiddenFieldRegistered())
  //              base.Page.RegisterHiddenField(this.OnceClickBtnName, "");

  //          base.OnInit(e);
  //      }

  //      private bool IsHiddenFieldRegistered()
  //      {
  //          foreach (Control ctl in base.Page.Controls)
  //          {
  //              if (ctl is HtmlControls.HtmlInputHidden)
  //              {
  //                  if (ctl.ID == this.OnceClickBtnName)
  //                      return true;
  //              }
  //          }

  //          return false;
  //      }

  //      protected virtual void OnClick(EventArgs e)
  //      {
  //          Click?.Invoke(this, e);
  //      }

  //      protected virtual void OnCommand(System.Web.UI.WebControls.CommandEventArgs e)
  //      {
  //          Command?.Invoke(this, e);
  //      }

  //      private void RaisePostBackEvent(string eventArgument)
  //      {
  //          if (this.CausesValidation)
  //              base.Page.Validate();

  //          this.OnClick(new EventArgs());
  //          this.OnCommand(new System.Web.UI.WebControls.CommandEventArgs(this.CommandName, this.CommandArgument));
  //      }
  //  }
}
