using System;
using System.Security.Cryptography;
using System.Text;

namespace cv_maker
{
    public static class Helpers
    {
        // GLOBAL OLEDB CONNECTION STRING
        public static string url_DB = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\user\\OneDrive\\Рабочий стол\\cv_maker\\cv_maker\\cv_maker\\bin\\Debug\\cv_maker1.mdb\"";

        // PAROLNI SHA-256 BILAN HASH QILISH FUNKSIYASI
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower(); // SHA-256 hash
            }
        }

        /*public static void GeneratePDF(string fullName, string email, string phone, string experience, string education, string skills, string countries, string socialLinks)
{
    string filePath = $"CV_{fullName.Replace(" ", "_")}.pdf";

    Document doc = new Document();
    PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
    doc.Open();

    // CV sarlavhasi
    Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
    Paragraph title = new Paragraph("Curriculum Vitae", titleFont);
    title.Alignment = Element.ALIGN_CENTER;
    doc.Add(title);
    doc.Add(new Paragraph("\n"));

    // Ma'lumotlarni qo'shish
    doc.Add(new Paragraph($"👤 Ism: {fullName}"));
    doc.Add(new Paragraph($"📧 Email: {email}"));
    doc.Add(new Paragraph($"📞 Telefon: {phone}"));
    doc.Add(new Paragraph($"💼 Tajriba: {experience}"));
    doc.Add(new Paragraph($"🎓 Ta'lim: {education}"));
    doc.Add(new Paragraph($"🔹 Ko'nikmalar: {skills}"));
    doc.Add(new Paragraph($"🌍 Mamlakatlar: {countries}"));
    doc.Add(new Paragraph($"🌐 Ijtimoiy Tarmoqlar: {socialLinks}"));
    doc.Add(new Paragraph("\n"));

    doc.Close();

    MessageBox.Show($"CV muvaffaqiyatli yaratildi! Fayl joylashuvi: {filePath}");
}*/



    }
}
