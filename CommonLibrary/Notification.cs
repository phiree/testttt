using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.UI;
using System.Web;
namespace CommonLibrary
{
    public enum NotificationType
    {
     success,
        error

    }

    public class Notification
    {

        public Notification()
        { 
         
        }
        public static void Show(Page page, string title, string content, string returnUrl)
        {
            Show(page, title, content, NotificationType.success, returnUrl,true,3);

        }
        public static void Show(Page page, string title, string content, string returnUrl, bool autoClose, int autoCloseDuration)
        {
            Show(page, title, content, NotificationType.success, returnUrl,autoClose, autoCloseDuration);

        }
        public static void Show(Page page, string title, string content, NotificationType type
            , string returnUrl
            ,bool autoClose
            , int autoCloseDuaratio)
        {
            string injectedScript = BuildInjectScript(title, content,type, returnUrl,autoClose,autoCloseDuaratio);
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "_nf", injectedScript, true);
        }
        
        private static string BuildInjectScript(string title, string content,
            NotificationType type, string returnUrl
            , bool autoClose
            ,int autocloseduration
            )
        {
            string notificationStyle = string.Empty;
            switch (type)
            {
                case NotificationType.error: notificationStyle = "error";
                    break;
                case NotificationType.success: notificationStyle = "success";
                    break;
            }
            string injectedScript = @"
$(function(){PopMsg('_title_','<div class=""_notificationStyle_"">_content_</div>','_returnUrl_',_autoclose_);});

function PopMsg(title,content, redirecturl,autoClose) {
            
            var ele = '<div id=""popMsg""></div>';
            $('form').append(ele);
            $('#popMsg').append(content);
$('#popMsg').append(""<div style='color:#999; position:absolute;bottom:5px;'>窗口将在<span id='altimer'></span>后自动关闭</div>"");

            var sec = 0;
            var outSec = _autocloseduration_;
            var interval = null;

            $('#popMsg').dialog({
                title:title,
modal:true,
                open: function (event, ui) {
                    sec = 0;
                    if (autoClose) {
                        interval = setInterval(closeTimer, 1000);
                    }
                    $('.ui-widget-overlay').bind('click', function () { $('#popMsg').dialog('close'); });
                }
                ,
                close: function (event, ui) {
                    if (redirecturl != null && redirecturl  != ''&&redirecturl!=undefined) {
                        window.location.href = redirecturl;
                    }
                }

            });

            function closeTimer() {
                if (sec >= outSec) {
                    $('#popMsg').dialog('close');
                    interval = null;
                }
                else {
                  $('#altimer').html(outSec-sec);
                    sec++;
                }
            }
        }";
            injectedScript = injectedScript.Replace("_title_", title).Replace("_content_", content).Replace("_returnUrl_", returnUrl)
                .Replace("_autocloseduration_", autocloseduration.ToString())
                .Replace("_notificationStyle_", notificationStyle)
                .Replace("_autoclose_",autoClose?"true":"false")
                ;
            return injectedScript;
        }
        
    }
    
}
