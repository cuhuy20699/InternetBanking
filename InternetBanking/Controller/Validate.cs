using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Controller
{
    class Validate
    {
        //check email
        public bool IsEmailValid(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        //check viết hoa
        public bool CapitalLetter(String input)
        {
            foreach (char c in input)
            {
                if (char.IsUpper(c)) return true;
            }
            return false;
        }

        //check dấu cách
        public bool Space(String input)
        {
            if (input.Contains(" ")) return true;
            return false;
        }


        //check số
        public bool Digit(String input)
        {
            if (input.Any(char.IsDigit)) return true;
            return false;
        }

        public string ValidateUserName(string name)
        {
            if (name != null && name.Length > 6 && name.Length < 50 && CapitalLetter(name) == true)
            {
                return name;
            }
            while (true)
            {
                Console.WriteLine("Username is invalid please enter it again.");
                Console.WriteLine("username: ");
                name = Console.ReadLine();
            }
        }

        public string ValidatePassword(string password)
        {
            if (password != null && password.Length > 6 && CapitalLetter(password) == true && Space(password) == false)
            {
                return password;
            }
            while (true)
            {
                Console.WriteLine("Password is invalid please enter it again.");
                Console.WriteLine("Password: ");
                password = Console.ReadLine();
            }
        }

        public string ValidateFullName(string fullname)
        {
            if (fullname != null && Digit(fullname) == false && fullname.Length > 10 && fullname.Length < 50)
            {
                return fullname;
            }
            while (true)
            {
                Console.WriteLine("Bạn có chắc bạn nhớ đúng tên mình không ? ");
                Console.WriteLine("FullName: ");
                fullname = Console.ReadLine();
            }

        }

        public int ValidateGender(string gender)
        {
            if (gender == "Male" || gender == "Nam")
            {
                return 1;
            }
            else if (gender == "Female" || gender == "Nữ")
            {
                return 0;
            }
            else if (gender == "Khác" || gender == "Other")
            {
                return 2;
            }
            while (true)
            {
                Console.WriteLine("Không có giống loài này tồn tại.");
                Console.WriteLine("Gender : ");
                gender = Console.ReadLine();
            }
        }

        public string ValidateIdNumber(string idNumber)
        {
            if (idNumber != null && idNumber.Length > 8) return idNumber;
            while (true)
            {
                Console.WriteLine("IdNumber is invalid please enter it again.");
                Console.WriteLine("ID Number: ");
                idNumber = Console.ReadLine();
            }
        }

        public string ValidatePhone(string phone)
        {
            if (phone != null && phone.Length > 9) return phone;
            else
            {
                Console.WriteLine("Bạn có số điện thoại không ?(Y/N)");
                string confirm = Console.ReadLine();
                if (confirm == "N")
                {
                    phone = "không có";
                    return phone;
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("số điện thoại không hợp lệ .");
                        Console.WriteLine("phone: ");
                        phone = Console.ReadLine();
                    }
                }
            }
        }


        public string ValidateEmail(string email)
        {
            if (IsEmailValid(email) == true && email != null)
            {
                return email;
            }
            else
            {
                Console.WriteLine("Bạn có email không ?(Y/N)");
                string confirm = Console.ReadLine();
                if (confirm == "N")
                {
                    email = "không có";
                    return email;
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("Email không hợp lệ .");
                        Console.WriteLine("Email: ");
                        email = Console.ReadLine();
                    }
                }
            }
        }

        public string ValidateAddress(string address)
        {
            if (address != null && address.Length > 10 && address.Length < 100) return address;
            while (true)
            {
                Console.WriteLine("Địa chỉ không hợp lệ, Vui lòng nhập lại.");
                Console.WriteLine("Address: ");
                address = Console.ReadLine();
            }
        }
    }
}
