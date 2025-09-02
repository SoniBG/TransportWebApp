namespace TransportWebApp.Application.Utilities;

public class EmailGenerator
{
    public string CreateEmailBody(string email, string confirmationLink)
    {
        return $@"
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset='utf-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1'>
                <title>Confirm Your Email</title>
                <style>
                    body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; max-width: 600px; margin: 0 auto; padding: 20px; }}
                    .header {{ background: #007bff; color: white; padding: 20px; text-align: center; border-radius: 5px 5px 0 0; }}
                    .content {{ background: #f8f9fa; padding: 30px; border-radius: 0 0 5px 5px; }}
                    .button {{ display: inline-block; padding: 12px 30px; background: #28a745; color: white; text-decoration: none; border-radius: 5px; margin: 20px 0; }}
                    .footer {{ margin-top: 20px; padding-top: 20px; border-top: 1px solid #dee2e6; font-size: 14px; color: #6c757d; }}
                </style>
            </head>
            <body>
                <div class='header'>
                    <h1>Welcome!</h1>
                </div>
                <div class='content'>
                    <h2>Confirm Your Email Address</h2>
                    <p>Hello,</p>
                    <p>Thank you for registering with our application. To complete your registration and activate your account, please confirm your email address by clicking the button below:</p>
                    <p style='text-align: center;'>
                        <a href='{confirmationLink}' class='button'>Confirm Email Address</a>
                    </p>
                    <p>If the button doesn't work, you can copy and paste this link into your browser:</p>
                    <p style='word-break: break-all; background: #e9ecef; padding: 10px; border-radius: 3px; font-family: monospace;'>{confirmationLink}</p>
                    <div class='footer'>
                        <p>If you didn't create an account with us, you can safely ignore this email.</p>
                        <p>This confirmation link will expire in 24 hours for security reasons.</p>
                    </div>
                </div>
            </body>
            </html>";
    }
}
