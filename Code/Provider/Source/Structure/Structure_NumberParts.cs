////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 27.02.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//struct Structure_NumberParts

struct Structure_NumberParts
{
 public string               Text;

 public Structure_NumberSign MantisseSign;

 public int                  IntPartBeg;
 public int                  IntPartEnd;

 public int                  FloatPartBeg;
 public int                  FloatPartEnd;

 public Structure_NumberSign ScaleSign;

 public int                  ScalePartBeg;
 public int                  ScalePartEnd;
};//struct Structure_NumberParts

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
