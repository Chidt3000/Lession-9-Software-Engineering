using System;

namespace StudentServiceLib
{
    public class Student
    {
        private double _score;

        public int Id { set; get; }
        public String Name { set; get; }
        public int Age { set; get; }

        /*
         Score chỉ tiếp nhận giá trị nằm trong phạm vi [0, 10]. Nếu gán giá trị nằm ngoài phạm vi này thì throw exception tên SystemException.
        Cần ít nhất 3 testcases ở đây
         */
        public double Score { 
            get => _score;
            set
            {
                if (_score > 10)
                {
                    throw new SystemException("Score must not exeed 10.0");
                }
                this._score = value;
            } 
        }

        /**
     * Trả về xếp loại của sinh viên theo ký tự A,B,C,D,E
            + [8, 10]: Loại A
            + [7, 8): Loại B
            + [5, 7): Loại C
            + [3.5, 5): Loại D
            + Dưới 3.5: Loại E

        CẦN TỐI THIỂU: 4 testcases
     */
        public char getLetterScore()
        {
            if (Score >= 8.0) return 'A';
            if (Score > 7.0) return 'B';
            if (Score > 5.0) return 'C';
            if (Score >= 3.5) return 'D';
            return 'E';
        }
    }
}
