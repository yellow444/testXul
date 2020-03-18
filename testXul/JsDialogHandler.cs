using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testXul
{
    public class JsDialogHandler : IJsDialogHandler
    {
        public bool OnJSDialog(IWebBrowser browserControl, IBrowser browser, string originUrl, CefJsDialogType dialogType, string messageText, string defaultPromptText, IJsDialogCallback callback, ref bool suppressMessage)
        {
            suppressMessage = true;
            return false;
        }

        public bool OnJSBeforeUnload(IWebBrowser browserControl, IBrowser browser, string message, bool isReload, IJsDialogCallback callback)
        {
            return true;
        }

        public void OnResetDialogState(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public void OnDialogClosed(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public bool OnBeforeUnloadDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, string messageText, bool isReload, IJsDialogCallback callback)
        {
            return true;
        }
    }
}
