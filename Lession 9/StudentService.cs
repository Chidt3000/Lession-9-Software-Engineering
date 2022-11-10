using System;
using System.Collections.Generic;
using System.Text;

namespace StudentServiceLib
{
    public class StudentService
    {
        private List<Student> students;

        public StudentService()
        {
            students = new List<Student>();
        }

        // phương thức này luôn đúng, không cần test
        // có thể dùng phương thức này cho mục đích viết unit test
        public int size()
        {
            return students.Count;
        }

        /* - Thêm sinh viên vào danh sách
             - Chỉ thêm khi mã số của sinh viên chưa tồn tại trong danh sách
             - Nếu tham số nhận vào là null thì ném ra ngoại lệ NullReferenceException
             - Nếu thêm thành công thì số lượng sinh viên tăng 1 và phương thức trả về true
             - Nếu thêm không thành công thì phương thức trả về false

             SỐ LƯỢNG TESTCASE TỐI THIỂU: 4
         * */
        public bool addStudent(Student s)
        {
            foreach (var x in students)
            {
                if (x.Id == s.Id)
                {
                    return true;
                }
            }

            students.Add(s);
            return true;
        }

        /* - Lấy sinh viên tại vị trí position 
                - Nếu position nằm ngoài phạm vi của mảng (0 -> n-1) thì ném ra ngoại lệ IndexOutOfRangeException
                - Nếu có ngoại lệ thì ngoại lệ phải có message là: 'Index {i} is not available in this array'. Trong đó {i} là giá trị của biến position.
                - Nếu vị trí nằm trong phạm vi của mảng thì cần đảm bảo trả về đúng người, đúng thông tin.

                SỐ LƯỢNG TESTCASE TỐI THIỂU: 3
        */
        public Student getStudentAt(int position)
        {
            if (position >= students.Count)
            {
                throw new IndexOutOfRangeException();
            }
            return students[position];
        }

        /* - Tìm một sinh viên theo tuổi
                - Trả về sinh viên đầu tiên tìm được
                - Nếu không tìm được thì trả về null

                SỐ LƯỢNG TESTCASE TỐI THIỂU: 2
         */
        public Student findStudentByAge(int age)
        {
            Student sv = null;
            foreach (var x in students)
            {
                if (x.Age == age)
                {
                    sv = x;
                    return sv;
                }
            }
            return sv;
        }

        /* - Tính điểm trung bình của toàn bộ sinh viên trong danh sách
             - Nếu chưa có sinh viên trong danh sách thì ném ra ngoại lệ SystemException
             - Ngoại lệ có message là "Student list is empty"

             SỐ LƯỢNG TESTCASE TỐI THIỂU: 3
         */
        public double getAverageScore()
        {
            if (students.Count == 0)
            {
                throw new SystemException("No student");
            }

            double sum = 0;
            foreach (var x in students)
            {
                sum += x.Score;
            }
            return sum / students.Count;
        }

        /* - Tìm sinh viên có điểm số thấp nhất trong lớp
             - Nếu lớp không có sinh viên nào thì trả về null
             - Nếu lớp có nhiều sinh viên cùng có điểm thấp nhất thì trả về sinh viên nằm ở cuối

             SỐ LƯỢNG TESTCASE TỐI THIỂU: 3
         **/
        public Student findStudentWithMinScore()
        {
            if (students.Count == 0)
            {
                return null;
            }

            // find min score
            double minScore = students[0].Score;
            foreach (var x in students)
            {
                if (x.Score < minScore)
                    minScore = x.Score;
            }

            // find student with min score
            foreach (var x in students)
            {
                if (x.Score == minScore)
                {
                    return x;
                }
            }

            return null;
        }
    }
}
