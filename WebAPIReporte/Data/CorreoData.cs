using System.Net;
using System.Net.Mail;

namespace WebAPIReporte.Data
{
    public class CorreoData
    {
        const string fromRemitente = "xxxxx@gmail.com";
        const string fromPassword = "xxxxx";

        public string EnviarCorreoSimple(string correo)
        {
            string msg = "";
            try
            {
                var fromAddress = new MailAddress(fromRemitente, "Corneshop");
                var toAddress = new MailAddress(correo, "Registro Cliente");
               
                const string subject = "Le damos la bienvenida";
                const string body = "Le damos la bienvenida a usted por formar parte de la empresa Corneshop";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);

                    msg = "Mensaje Enviado Correctamente!!";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }


        public string EnviarCorreoHtml(string correo)
        {
            string msg = "";
            try
            {
                var fromAddress = new MailAddress(fromRemitente, "Corneshop");
                var toAddress = new MailAddress(correo, "Registro Colaborador");
                const string subject = "Le damos la bienvenida";

                string body = "";
;
                body = @"<html>
                        <head>
	                        <title></title>
                        </head>
                        <style>
                       .button {
                            color: black;
                            font-family: 'Barrio', cursive;
                            border: 1px solid black;
                            font-size: 20px !important;
                            text-decoration:none;
                            padding:5px;
                            border-radius: 15px 50px 30px 5px;
                        }

                        .contenedor {
                            border-color: #ddd !important;
                            padding-top: 45px !important;

                            border: 1px solid #ddd !important;
                            box-sizing: inherit;
                            margin-top: 45px;
                            padding-right: 45px !important;
                            padding-left: 45px !important;
                            margin-right: 20px;
                            margin-left: 20px;
                            text-align:justify;
                        }
                        </style>
                        <body>
                        
                        <div class='contenedor'   style='font-family:Geneva,Arial,Helvetica,sans-serif; font-size:13pt;'>
                             <img src = '@__LINK_BANNER_SRC__' />
                            <div class='container'>
                             <p>Estimado(a) </p>
                            <p>Mediante el presente se envia el link para la evaluación del servicio brindado por el colaborador <strong>@__DATOS_PERSONA__</strong> 
                            con el objetivo de mejorar continuamente como empresa.<br>
                            Agradecemos su apoyo.</p>
                            <br>
                            <a class='button' href = '@__URL_ENCODED__'><img width = '20' height = '20' src = '@__LINK_ICON_SRC__'> @nPersona.-Eval.</a></p>
                            <br/>
                           <p>Saludos.</p>
                           <br/>
                            <table>
                                <tr>
                                    <td>
                                        <img width = '150' height = '63' src = '@__LOGO_URL_SRC__' alt = '' >
                                    </td>
                                </tr>
                            </table>
                            </div>
                        </div>";
                // string img1 = AppDomain.CurrentDomain.BaseDirectory

                Attachment attFile1 = new Attachment("Images/banner-admi.jpg");
              //  attFile1.ContentId = "image001.jpg";
              //  attFile1.Name = "image001.jpg";

                Attachment attFile2 = new Attachment("Images/logoUTP.jpg");
                Attachment attFile3 = new Attachment("Images/icon-link.png");
   
                body = body.Replace("@__URL_ENCODED__", "https://www.utp.edu.pe/utpmas");
                body = body.Replace("@__LINK_BANNER_SRC__", attFile1.Name);
                body = body.Replace("@__LOGO_URL_SRC__", attFile2.Name);
                body = body.Replace("@__LINK_ICON_SRC__", attFile3.Name);
                body = body.Replace("@nPersona", "Jose");
                body = body.Replace("@__DATOS_PERSONA__", "Jose Luis Castro Ll.");

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                MailMessage mMailMessage = new MailMessage(fromAddress, toAddress);
                mMailMessage.Attachments.Add(attFile1);
                mMailMessage.Attachments.Add(attFile2);
                mMailMessage.Attachments.Add(attFile3);
                mMailMessage.IsBodyHtml = true;
                mMailMessage.Subject = subject;
                mMailMessage.Body = body;

                smtp.Send(mMailMessage);

                msg = "Correo Enviado Correctamente!!";
            }
            catch (Exception ex){
                msg = ex.Message;
            }

            return msg;
        }

        public string EnviarCorreoHtml2(string correo)
        {
            string msg = "";
            string sAsunto = "Evaluación Colaborador";

            MailMessage mMailMessage = new MailMessage();
            mMailMessage.IsBodyHtml = true;
            mMailMessage.From = new MailAddress(fromRemitente, "Atención SED");
            mMailMessage.To.Add(new MailAddress(correo));
            mMailMessage.Subject = sAsunto;
            mMailMessage.Body = ArmaBody("Jose Castro");

            var mSmtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromRemitente, fromPassword)
            };

            try
            {
                mSmtpClient.Send(mMailMessage);
                msg = "Correo Enviado Correctamente!!";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }


        public string ArmaBody(string cuerpo)
        {
            string body = "<!DOCTYPE html>";
            body += "<html lang=='en'><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' />";
            body += "<title>Correo SAR</title>";
            body += "<style>	.tabla_footer {		width:100%;		background-color:Transparent;		margin:auto;		border-width:0px;		border-style:solid;		border-color:#FFFFFF;	}		.footer 	{		width:100%;		height:250px;		vertical-align:bottom;		border-width:0px;		border-style:solid;		border-color:#FFFFFF;	}		.espacio	{		padding-top:0px;		border-width:0px;		border-style:solid;		border-color:#FFFFFF;	}		.footer_hr	{		width:350px;		color:#AAA;	}		.footer_div	{		width:auto;		text-align:center;		color:#777;		border-width:0px;		border-style:solid;		border-color:#FFFFFF;	}	.tabla_contenedor {		width:100%;		height:100%;		border-width:0px;		border-style:solid;		border-color:#FFFFFF;		margin:auto;		vertical-align:middle;	}		.logo {		width:50%;		height:69px;		border-width:0px;		border-style:solid;		border-color:#FFFFFF;		margin:auto;	}	.tabla_maestra {		width:100%;		height:100%;		border-width:0px;		border-style:solid;		border-color:#FFFFFF; background-repeat:no-repeat;	}</style>";
            body += "</head><body><table class='tabla_maestra' cellpadding=0 cellspacing=0>";
            body += "<tr><td align='center'><img src='https://1.bp.blogspot.com/-dWMR-_x9wJE/YEWvBMI4XMI/AAAAAAAAUtc/AhklvEn53xEjV7gimuwoDVyKgBJYoJKtACLcBGAsYHQ/s557/banner%2Butp.png' /></td></tr>";
            body += "<tr><td>";
            body += cuerpo;
            body += "</td></tr><tr><td><div class='footer_div'>© " + DateTime.Now.Year.ToString() + " SES - SAR 4.0 - Todos los derechos reservados.</div></td></tr><tr></table></body></html>";

            return body;
        }
    }
}
