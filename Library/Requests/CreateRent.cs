using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Requests
{
    public class CreateRent
    {
        public DateTime DateStart { get; set; }// ���� ������
        public DateTime DateEnd { get; set; }// ���� ��������
        public int IdReader { get; set; }
        public int IdBook { get; set; }
        
    }
}