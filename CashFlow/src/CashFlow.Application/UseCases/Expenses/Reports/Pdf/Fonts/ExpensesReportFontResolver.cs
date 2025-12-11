using PdfSharp.Charting;
using PdfSharp.Fonts;

namespace CashFlow.Application.UseCases.Expenses.Reports.Pdf.Fonts;

public class ExpensesReportFontResolver : IFontResolver
{
    byte[]? IFontResolver.GetFont(string faceName)
    {
        throw new NotImplementedException();
    }

    FontResolverInfo? IFontResolver.ResolveTypeface(string familyName, bool bold, bool italic)
    {

        return new FontResolverInfo(familyName);
    }
}
