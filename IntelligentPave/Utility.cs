using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Autodesk.Revit;
using Autodesk.Revit.DB;
namespace RevitRedevelop.UI.Pave
{
    class WallTypeComparer : IComparer<WallType>
    {
        public int Compare(WallType x, WallType y)
        {
            string xName = x.Name;
            string yName = y.Name;
           

            IComparer comp = new CaseInsensitiveComparer();
            return comp.Compare(xName, yName);
        }
        
    }

    class ViewComparer : IComparer<Autodesk.Revit.DB.View>
    {
        public int Compare(Autodesk.Revit.DB.View x, Autodesk.Revit.DB.View y)
        {
            string xName = x.ViewType.ToString() + " : " + x.Name;
            string yName = y.ViewType.ToString() + " : " + y.Name;

            IComparer comp = new CaseInsensitiveComparer();
            return comp.Compare(xName, yName);
        }
    }
    class LevelComparer : IComparer<Autodesk.Revit.DB.Level>
    {
        public int Compare(Level x, Level y)
        {
            string xName = x.LevelType.ToString() + " : " + x.Name;
            string yName = y.LevelType.ToString() + " : " + y.Name;

            IComparer comp = new CaseInsensitiveComparer();
            return comp.Compare(xName, yName);
        }
    }

    public class Vector4
    {
        #region Fields
        private float m_x;
        private float m_y;
        private float m_z;
        private float m_w = 1.0f;
        #endregion

        #region Properties

        public float X
        {
            get
            {
                return m_x;
            }
            set
            {
                m_x = value;
            }
        }
        public float Y
        {
            get
            {
                return m_y;
            }
            set
            {
                m_y = value;
            }
        }
        public float Z
        {
            get
            {
                return m_z;
            }
            set
            {
                m_z = value;
            }
        }
        public float W
        {
            get
            {
                return m_w;
            }
            set
            {
                m_w = value;
            }
        }
        #endregion

        #region Constructors
        public Vector4(float x, float y, float z)
        {
            this.X = x; this.Y = y; this.Z = z;
        }

        public Vector4(Autodesk.Revit.DB.XYZ v)
        {
            this.X = (float)v.X; this.Y = (float)v.Y; this.Z = (float)v.Z;
        }
        #endregion

        #region Public methods
    
        public static Vector4 operator +(Vector4 va, Vector4 vb)
        {
            return new Vector4(va.X + vb.X, va.Y + vb.Y, va.Z + vb.Z);
        }

        public static Vector4 operator -(Vector4 va, Vector4 vb)
        {
            return new Vector4(va.X - vb.X, va.Y - vb.Y, va.Z - vb.Z);
        }

        public static Vector4 operator *(Vector4 v, float factor)
        {
            return new Vector4(v.X * factor, v.Y * factor, v.Z * factor);
        }

        public static Vector4 operator /(Vector4 v, float factor)
        {
            return new Vector4(v.X / factor, v.Y / factor, v.Z / factor);
        }

        public float DotProduct(Vector4 v)
        {
            return (this.X * v.X + this.Y * v.Y + this.Z * v.Z);
        }

        public Vector4 CrossProduct(Vector4 v)
        {
            return new Vector4(this.Y * v.Z - this.Z * v.Y, this.Z * v.X
                - this.X * v.Z, this.X * v.Y - this.Y * v.X);
        }

        public static float DotProduct(Vector4 va, Vector4 vb)
        {
            return (va.X * vb.X + va.Y * vb.Y + va.Z * vb.Z);
        }

        public static Vector4 CrossProduct(Vector4 va, Vector4 vb)
        {
            return new Vector4(va.Y * vb.Z - va.Z * vb.Y, va.Z * vb.X
                - va.X * vb.Z, va.X * vb.Y - va.Y * vb.X);
        }

        public void Normalize()
        {
            float length = Length();
            if (length == 0)
            {
                length = 1;
            }
            this.X /= length;
            this.Y /= length;
            this.Z /= length;
        }

        public float Length()
        {
            return (float)Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
        }
        #endregion
    };

    /// <summary>
    /// 
    /// Matrix4
    /// 
    /// </summary>
    public class Matrix4
    {
      
      public enum MatrixType
      {
        
         Rotation,

         Translation,

         Scale,

         RotationAndTranslation,

         Normal
      };

      #region Fields
      // an array stores the matrix
      private float[,] m_matrix = new float[4, 4];

      //type of matrix
      private MatrixType m_type;
      #endregion

      #region Properties and indexeres
     
      public float this[int row, int column]
      {
         get
         {
            return this.m_matrix[row, column];
         }
         set
         {
            this.m_matrix[row, column] = value;
         }
      }
      #endregion

      #region Constructors
     
      public Matrix4()
      {
         m_type = MatrixType.Normal;
         Identity();
      }

      public Matrix4(Vector4 xAxis, Vector4 yAxis, Vector4 zAxis)
      {
         m_type = MatrixType.Rotation;
         Identity();
         m_matrix[0, 0] = xAxis.X; m_matrix[0, 1] = xAxis.Y; m_matrix[0, 2] = xAxis.Z;
         m_matrix[1, 0] = yAxis.X; m_matrix[1, 1] = yAxis.Y; m_matrix[1, 2] = yAxis.Z;
         m_matrix[2, 0] = zAxis.X; m_matrix[2, 1] = zAxis.Y; m_matrix[2, 2] = zAxis.Z;

      }

      public Matrix4(Vector4 origin)
      {
         m_type = MatrixType.Translation;
         Identity();
         m_matrix[3, 0] = origin.X; m_matrix[3, 1] = origin.Y; m_matrix[3, 2] = origin.Z;
      }

      public Matrix4(Vector4 xAxis, Vector4 yAxis, Vector4 zAxis, Vector4 origin)
      {
         m_type = MatrixType.RotationAndTranslation;
         Identity();
         m_matrix[0, 0] = xAxis.X; m_matrix[0, 1] = xAxis.Y; m_matrix[0, 2] = xAxis.Z;
         m_matrix[1, 0] = yAxis.X; m_matrix[1, 1] = yAxis.Y; m_matrix[1, 2] = yAxis.Z;
         m_matrix[2, 0] = zAxis.X; m_matrix[2, 1] = zAxis.Y; m_matrix[2, 2] = zAxis.Z;
         m_matrix[3, 0] = origin.X; m_matrix[3, 1] = origin.Y; m_matrix[3, 2] = origin.Z;
      }

      public Matrix4(float scale)
      {
         m_type = MatrixType.Scale;
         Identity();
         m_matrix[0, 0] = scale;
         m_matrix[1, 1] = scale;
         m_matrix[2, 2] = scale;
      }
      #endregion

      #region Public methods
 
      public void Identity()
      {
         for (int i = 0; i < 4; i++)
         {
            for (int j = 0; j < 4; j++)
            {
               this.m_matrix[i, j] = 0.0f;
            }
         }
         this.m_matrix[0, 0] = 1.0f;
         this.m_matrix[1, 1] = 1.0f;
         this.m_matrix[2, 2] = 1.0f;
         this.m_matrix[3, 3] = 1.0f;
      }

      public static Matrix4 Multiply(Matrix4 left, Matrix4 right)
      {
         Matrix4 result = new Matrix4();
         for (int i = 0; i < 4; i++)
         {
            for (int j = 0; j < 4; j++)
            {
               result[i, j] = left[i, 0] * right[0, j] + left[i, 1] * right[1, j]
                   + left[i, 2] * right[2, j] + left[i, 3] * right[3, j];
            }
         }
         return result;
      }

      public Vector4 Transform(Vector4 point)
      {
         return new Vector4(point.X * this[0, 0] + point.Y * this[1, 0]
             + point.Z * this[2, 0] + point.W * this[3, 0],
             point.X * this[0, 1] + point.Y * this[1, 1]
             + point.Z * this[2, 1] + point.W * this[3, 1],
             point.X * this[0, 2] + point.Y * this[1, 2]
             + point.Z * this[2, 2] + point.W * this[3, 2]);
      }

      public Matrix4 RotationInverse()
      {
         return new Matrix4(new Vector4(this[0, 0], this[1, 0], this[2, 0]),
             new Vector4(this[0, 1], this[1, 1], this[2, 1]),
             new Vector4(this[0, 2], this[1, 2], this[2, 2]));
      }

      public Matrix4 TranslationInverse()
      {
         return new Matrix4(new Vector4(-this[3, 0], -this[3, 1], -this[3, 2]));
      }

      public Matrix4 Inverse()
      {
         switch (m_type)
         {
            case MatrixType.Rotation:
               return RotationInverse();

            case MatrixType.Translation:
               return TranslationInverse();

            case MatrixType.RotationAndTranslation:
               return Multiply(TranslationInverse(), RotationInverse());

            case MatrixType.Scale:
               return ScaleInverse();

            case MatrixType.Normal:
               return new Matrix4();

            default: return null;
         }
      }
      public Matrix4 ScaleInverse()
      {
         return new Matrix4(1 / m_matrix[0, 0]);
      }
      #endregion
   };

   public struct PointD
   {
      #region Fields
      // X coordinate
      double m_x;

      // Y coordinate
      double m_y;
      #endregion

      #region Properties

      public double X
      {
         get
         {
            return m_x;
         }
         set
         {
            m_x = value;
         }
      }

      public double Y
      {
         get
         {
            return m_y;
         }
         set
         {
            m_y = value;
         }
      }
      #endregion

      #region Constructors

      public PointD(double x, double y)
      {
         m_x = x;
         m_y = y;
      }
      #endregion
   }

}
