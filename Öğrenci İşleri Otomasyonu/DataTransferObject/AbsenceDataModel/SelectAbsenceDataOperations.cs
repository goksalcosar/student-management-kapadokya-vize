using Microsoft.EntityFrameworkCore;
using Öğrenci_İşleri_Otomasyonu.DataObjects;
using Öğrenci_İşleri_Otomasyonu.Definition;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.AbsenceDataModel
{
    public class SelectAbsenceDataOperations
    {
        public static List<object> getAbsence()
        {
            return (from item in (new MainContext()).StudentManagementContext.Absences
                    select new
                    {
                        Devamsızlık_Id = item.Id,
                        Öğrenci = item.User.Name + " " + item.User.Surname,
                        Mazeretli_İzin_Sayısı = item.ExcusedAbsence.ToString(),
                        Mazeretsiz_İzin_Saysı = item.UnexcusedAbsence.ToString(),
                        Devamsızlık_Günü = item.CreatedAt.ToString("dd/MM/yy"),
                    }).ToList<object>();
        }

        public static List<object> getAbsenceFilteringCitionNumber(string citionNumber)
        {
            return (from item in (new MainContext()).StudentManagementContext.Absences
                    where item.User.TcNo == citionNumber
                    select new
                    {
                        Devamsızlık_Id = item.Id,
                        Öğrenci = item.User.Name + " " + item.User.Surname,
                        Mazeretli_İzin_Sayısı = item.ExcusedAbsence.ToString(),
                        Mazeretsiz_İzin_Saysı = item.UnexcusedAbsence.ToString(),
                        Devamsızlık_Günü = item.CreatedAt.ToString("dd/MM/yy"),
                    }).ToList<object>();
        }

        public static Absence GetFindByIdAbsence(int absenceId, StudentManagementContext studentManagementContext)
        {
            return studentManagementContext.Absences
                .Include(user => user.User)
                .FirstOrDefault(absence => absence.Id == absenceId);
        }

        public static AbsenceDefinition GetFindByFullNameStudentAbsenceData(string fullName, StudentManagementContext studentManagementContext)
        {
            var absences = (from item in (new MainContext()).StudentManagementContext.Absences
                            where (item.User.Name + " " + item.User.Surname) == fullName
                            select new
                            {
                                ExcusedAbsence = item.ExcusedAbsence,
                                UnexcusedAbsence = item.UnexcusedAbsence
                            }).ToList();

            double totalExcusedAbsence = absences.Sum(a => TryParseDouble(a.ExcusedAbsence));
            double totalUnexcusedAbsence = absences.Sum(a => TryParseDouble(a.UnexcusedAbsence));

            return new AbsenceDefinition
            {
                TotalExcusedAbsence = totalExcusedAbsence,
                TotalUnexcusedAbsence = totalUnexcusedAbsence
            };
        }

        private static double TryParseDouble(string input)
        {
            double result;
            if (double.TryParse(input, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }
    }
}
