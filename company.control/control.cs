using System.Data;
using System.Globalization;
using System.IO.Pipes;
using System.Runtime.Intrinsics.X86;
using Company.datalayer;
namespace company.control
{


    public class Emp
    {
        public Emp() { }
        public Emp(string fname, string lname, string ssn, string adress)
        {

            Ssn = ssn;
            Fname = fname;
            Lname = lname;
            Address = adress;

        }
        public string Ssn { get; set; }
        public string Fname { get; set; }

        public string Lname { get; set; }
        public string Address { get; set; }


        public override string ToString()
        {
            return $"{Ssn}:{Fname}:{Lname}:{Address}:";
        }

    }
    public class Control_emp
    {
        public static  DataTable  get_all()
        {

            return DBmanger.GetData("select * from employee");


        }

        public  static  Emp getbyid(string id )
        {

            var  dt =  DBmanger.GetData($"select fname , lname , address ,ssn from employee where ssn='{id}'");
            Emp person = new Emp()
            {
                Fname = dt.Rows[0]["fname"].ToString(),
                Lname = dt.Rows[0]["lname"].ToString()
        ,
                Address = dt.Rows[0]["address"].ToString(),
                Ssn = dt.Rows[0]["ssn"].ToString()
            };
            return person;
        }
        public static DataTable getbyid1(string id)
        {

            var dt = DBmanger.GetData($"select fname , lname , address ,ssn from employee where ssn='{id}'");

            return dt;
        }


        public static int update(Emp person )
        {


         return   DBmanger.modify($"update Employee set fname ='{person.Fname}',lname ='{person.Lname}',address ='{person.Address}'where ssn ='{person.Ssn}' ");

        }
        public static int insert (Emp person)
        {


            return DBmanger.modify($" insert into Employee (SSN,Fname,Lname,Address) values ('{person.Ssn}','{person.Fname}','{person.Lname}','{person.Address}') ");

        }

        public static int delete(string   ssn)
        {


            return DBmanger.modify($"  delete from Employee where ssn = '{ssn}'");

        }


    }
}