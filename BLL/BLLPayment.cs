using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Com.Alipay;
using IDAL;
namespace BLL
{
    public class BLLPayment
    {

        IPayment ipayment;
        public IPayment IDalPayment
        {
            get {
                if (ipayment == null)
                {
                    ipayment = new DAL.DALPayment();
                }
                return ipayment;
            }
            set {
                ipayment = value;
            }
        }

        Order order;
        public decimal PayAmount
        {
            get;
            set;
        }
        public BLLPayment(Model.Order order)
        {
            this.order = order;
        }
        public BLLPayment()
        { }
        //订单内的总价 和 明细总价 是否一致
        public bool Validate()
        {
            return true;
        }


       

        /// <summary>
        /// 返回一个html form 字符串 ,
        /// </summary>
        /// <returns></returns>
        public string  Pay()
        {
            //请与贵网站订单系统中的唯一订单号匹配
            string out_trade_no = order.Id.ToString();
            //订单名称，显示在支付宝收银台里的“商品名称”里，显示在支付宝的交易管理的“商品名称”的列表里。
            string subject ="中国旅游在线-在线购票-"+order.Description;
            //订单描述、订单详细、订单备注，显示在支付宝收银台里的“商品描述”里
            string body = order.Description;
            //订单总金额，显示在支付宝收银台里的“应付总额”里
            decimal total_fee =decimal.Parse( order.TotalPrice.ToString("0.00"));
       //扩展功能参数——默认支付方式//

            //默认支付方式，代码见“即时到帐接口”技术文档
            string paymethod = "";
            //默认网银代号，代号列表见“即时到帐接口”技术文档“附录”→“银行列表”
            string defaultbank = "";

    //扩展功能参数——防钓鱼//

            //防钓鱼时间戳
            string anti_phishing_key = "";
            //获取客户端的IP地址，建议：编写获取客户端IP地址的程序
            string exter_invoke_ip = "";
            //注意：
            //请慎重选择是否开启防钓鱼功能
            //exter_invoke_ip、anti_phishing_key一旦被设置过，那么它们就会成为必填参数
            //建议使用POST方式请求数据
            //示例：
            //exter_invoke_ip = "";
            //Service aliQuery_timestamp = new Service();
            //anti_phishing_key = aliQuery_timestamp.Query_timestamp();               //获取防钓鱼时间戳函数

    //扩展功能参数——其他//

            //商品展示地址，要用http:// 格式的完整路径，不允许加?id=123这类自定义参数
            string show_url = "";
            //自定义参数，可存放任何内容（除=、&等特殊字符外），不会显示在页面上
            //系统内部的支付交易号
            string extra_common_param = Guid.NewGuid().ToString();
            //默认买家支付宝账号
            string buyer_email = "";

            //扩展功能参数——分润(若要使用，请按照注释要求的格式赋值)//

            //提成类型，该值为固定值：10，不需要修改
            string royalty_type = "";
            //提成信息集
            string royalty_parameters = "";
            //注意：
            //与需要结合商户网站自身情况动态获取每笔交易的各分润收款账号、各分润金额、各分润说明。最多只能设置10条
            //各分润金额的总和须小于等于total_fee
            //提成信息集格式为：收款方Email_1^金额1^备注1|收款方Email_2^金额2^备注2
            //示例：
            //royalty_type = "10";
            //royalty_parameters = "111@126.com^0.01^分润备注一|222@126.com^0.01^分润备注二";

            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("payment_type", "1");
            sParaTemp.Add("show_url", show_url);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("body", body);
            sParaTemp.Add("total_fee", total_fee.ToString("0.00"));
            sParaTemp.Add("paymethod", paymethod);
            sParaTemp.Add("defaultbank", defaultbank);
            sParaTemp.Add("anti_phishing_key", anti_phishing_key);
            sParaTemp.Add("exter_invoke_ip", exter_invoke_ip);
            sParaTemp.Add("extra_common_param", extra_common_param);
            sParaTemp.Add("buyer_email", buyer_email);
            sParaTemp.Add("royalty_type", royalty_type);
            sParaTemp.Add("royalty_parameters", royalty_parameters);

            //构造即时到帐接口表单提交HTML数据，无需修改
            Service ali = new Service();
            string sHtmlText = ali.Create_direct_pay_by_user(sParaTemp);
            TourLog.LogPayment("生成的参数是:" + sHtmlText);
           // Response.Write(sHtmlText);
            /////////////////记录支付信息/////////////
            Payment payment = new Payment();
            payment.Order = order;
            payment.PayAmount =total_fee;
            payment.PayType = PayType.AliPay;
            payment.EndPay = DateTime.Now;
            payment.RequestStringToPay = sHtmlText;

            IDalPayment.Save(payment);
            
            

            return sHtmlText;
        }

        /// <summary>
        /// 退款/退订
        /// </summary>
        /// <returns></returns>
        public string PayBack(Refund refund)
        {
           // 卖家用户ID  
           // string seller_user_id = Seller_user_id.Text.Trim();
            //卖家支付宝账号对应的支付宝唯一用户号。以2088开头的纯16位数字。

            //退款批次号
            string batch_no = refund.RefundSerialNo;

            //格式为：退款日期（8位当天日期）+流水号（3～24位，不能接受“000”，但是可以接受英文字符）。

            //退款请求时间
            string refund_date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            //退款请求的当前时间。格式为：yyyy-MM-dd hh:mm:ss

            //退款总笔数
            string batch_num = "1";//Batch_num.Text.Trim();
            //即参数detail_data的值中，“#”字符出现的数量加1，最大支持1000笔（即“#”字符出现的最大数量999个）。


            //单笔数据集
            string detail_data = refund.Order.TradeNo + "^" +refund.TotalReturnAmount +"^" + "退款旅游" ;
            //退款请求的明细数据。格式详见“4.3 单笔数据集参数说明”。
            
            ////////////////////////////////////////////////////////////////////////////////////////////////

            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();

            sParaTemp.Add("seller_user_id", Config.Partner);
            sParaTemp.Add("batch_no", batch_no);
            sParaTemp.Add("refund_date", refund_date);
            sParaTemp.Add("batch_num", batch_num);
            sParaTemp.Add("detail_data", detail_data);
            




            //构造即时到账批量退款有密接口表单提交HTML数据，无需修改
            Service ali = new Service();
            string sHtmlText = ali.Refund_fastpay_by_platform_pwd(sParaTemp);
            return sHtmlText;
        }

        /// <summary>
        /// 保存返回结果.
        /// </summary>
        /// <param name="receivedMsg"></param>
        public void Received( string receivedMsg) {

            try
            {
                Payment payment = IDalPayment.GetByOrder(order.Id);
                payment.ReceivedStringFromPay = receivedMsg;
                
                payment.EndPay = DateTime.Now;
                IDalPayment.Save(payment);
            }
            catch { 
              
            }

          
        }



        public void Success()
        {
            order.IsPaid = true;
            order.PayTime = DateTime.Now;
            BLLOrder bllOrder = new BLLOrder();
            bllOrder.SaveOrUpdateOrder(order);
        }
    }
}
