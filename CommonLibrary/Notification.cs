using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.UI;
using System.Web;
namespace CommonLibrary
{
    public class Notification
    {
        public static void Show(Page page, string title, string content,string returnUrl)
        {
            string injectedScript = BuildInjectScript(title, content, returnUrl,5);
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "_nf", injectedScript, true);
        }
        private static string BuildInjectScript(string title, string content, string returnUrl,int autocloseduration)
        {
            string injectedScript = @"
$(function(){PopMsg('_title_','_content_','_returnUrl_',true);});

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
            injectedScript = injectedScript.Replace("_title_", title).Replace("_content_", content).Replace("_returnUrl_",returnUrl)
                .Replace("_autocloseduration_",autocloseduration.ToString());
            return injectedScript;
        }
        
    }
    
}
