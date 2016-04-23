using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classString
{
	public class MyArray : ICloneable
	{

		private int firstIndex, lastIndex;
		string[] arr;

		public MyArray(int firstIndex, int lastIndex)
		{

			if (firstIndex >= lastIndex)
				throw new ArgumentException("первый индекс должен быть меньше последнего");
			this.firstIndex = firstIndex; // инициализируем границы
			this.lastIndex = lastIndex;
			arr = new string[lastIndex - firstIndex + 1];
		}

		public int FirstIndex
		{
			get { return firstIndex; }
		}

		public int LastElemPos
		{

			get { return arr.Length + firstIndex; }
		}

		public string this[int pos]
		{
			get
			{
				if (pos < firstIndex || pos > lastIndex)
					throw new ArgumentOutOfRangeException("Вышли за границы массива");
				else
					return arr[pos - firstIndex];
			}
			set
			{
				if (pos < firstIndex || pos > lastIndex)
					throw new ArgumentOutOfRangeException("Вышли за границы массива :(");
				else
					arr[pos - firstIndex] = value;
			}
		}


		public object Clone() // клонирование
		{
			MyArray copy = new MyArray(this.firstIndex, this.lastIndex);
			for (int i = 0; i < copy.arr.Length; i++)
			{
				copy.arr[i] = this.arr[i];
			}
			return copy;
		}





		public static MyArray Concat(MyArray arr1, MyArray arr2)  //объединяем массивы
		{
			MyArray temp1 = (MyArray)arr1.Clone();
			MyArray temp2 = (MyArray)arr2.Clone();

			int temp = temp1.arr.Length;
			Array.Resize(ref temp1.arr, temp1.arr.Length + temp2.arr.Length);
			temp1.lastIndex += temp2.arr.Length;
			temp2.arr.CopyTo(temp1.arr, temp);
			return temp1;

		}


		public static MyArray Merge(MyArray pArr1, MyArray pArr2)
		{
			MyArray arr1 = (MyArray)pArr1.Clone();
			MyArray arr2 = (MyArray)pArr2.Clone();

			int sizeForAdd = arr2.arr.Length;
			for (int i = 0; i < arr1.arr.Length; i++)
			{
				for (int j = 0; j < arr2.arr.Length; j++)
				{
					if (arr1.arr[i] == arr2.arr[j]) // если нашли совпадения, повторяющемуся эл-ту присваиваем null
					{
						arr2.arr[j] = null;
						sizeForAdd--;
					}
				}
			}

			int temp = arr1.arr.Length;
			Array.Resize(ref arr1.arr, arr1.arr.Length + sizeForAdd);

			for (int i = 0; i < arr2.arr.Length; i++)
			{
				if (arr2.arr[i] != null)
				{
					arr1.arr[temp] = arr2.arr[i];
					temp++;
				}
			}

			arr1.lastIndex += sizeForAdd;
			return arr1;

		}

	}

}