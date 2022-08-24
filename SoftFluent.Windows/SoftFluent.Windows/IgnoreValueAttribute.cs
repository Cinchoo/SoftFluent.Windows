using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;

namespace SoftFluent.Windows
{
    [AttributeUsage(AttributeTargets.All)]
    public class IgnoreValueAttribute : Attribute
    {
        /// <devdoc>
        ///     This is the default value.
        /// </devdoc>
        private object value;

        /// <devdoc>
        /// <para>Initializes a new instance of the <see cref='System.ComponentModel.IgnoreValueAttribute'/> class, converting the
        ///    specified value to the
        ///    specified type, and using the U.S. English culture as the
        ///    translation
        ///    context.</para>
        /// </devdoc>
        public IgnoreValueAttribute(Type type, string value)
        {

            // The try/catch here is because attributes should never throw exceptions.  We would fail to
            // load an otherwise normal class.
            try
            {
                this.value = TypeDescriptor.GetConverter(type).ConvertFromInvariantString(value);
            }
            catch
            {
                Debug.Fail("Default value attribute of type " + type.FullName + " threw converting from the string '" + value + "'.");
            }
        }

        /// <devdoc>
        /// <para>Initializes a new instance of the <see cref='System.ComponentModel.IgnoreValueAttribute'/> class using a Unicode
        ///    character.</para>
        /// </devdoc>
        public IgnoreValueAttribute(char value)
        {
            this.value = value;
        }
        /// <devdoc>
        /// <para>Initializes a new instance of the <see cref='System.ComponentModel.IgnoreValueAttribute'/> class using an 8-bit unsigned
        ///    integer.</para>
        /// </devdoc>
        public IgnoreValueAttribute(byte value)
        {
            this.value = value;
        }
        /// <devdoc>
        /// <para>Initializes a new instance of the <see cref='System.ComponentModel.IgnoreValueAttribute'/> class using a 16-bit signed
        ///    integer.</para>
        /// </devdoc>
        public IgnoreValueAttribute(short value)
        {
            this.value = value;
        }
        /// <devdoc>
        /// <para>Initializes a new instance of the <see cref='System.ComponentModel.IgnoreValueAttribute'/> class using a 32-bit signed
        ///    integer.</para>
        /// </devdoc>
        public IgnoreValueAttribute(int value)
        {
            this.value = value;
        }
        /// <devdoc>
        /// <para>Initializes a new instance of the <see cref='System.ComponentModel.IgnoreValueAttribute'/> class using a 64-bit signed
        ///    integer.</para>
        /// </devdoc>
        public IgnoreValueAttribute(long value)
        {
            this.value = value;
        }
        /// <devdoc>
        /// <para>Initializes a new instance of the <see cref='System.ComponentModel.IgnoreValueAttribute'/> class using a
        ///    single-precision floating point
        ///    number.</para>
        /// </devdoc>
        public IgnoreValueAttribute(float value)
        {
            this.value = value;
        }
        /// <devdoc>
        /// <para>Initializes a new instance of the <see cref='System.ComponentModel.IgnoreValueAttribute'/> class using a
        ///    double-precision floating point
        ///    number.</para>
        /// </devdoc>
        public IgnoreValueAttribute(double value)
        {
            this.value = value;
        }
        /// <devdoc>
        /// <para>Initializes a new instance of the <see cref='System.ComponentModel.IgnoreValueAttribute'/> class using a <see cref='System.Boolean'/>
        /// value.</para>
        /// </devdoc>
        public IgnoreValueAttribute(bool value)
        {
            this.value = value;
        }
        /// <devdoc>
        /// <para>Initializes a new instance of the <see cref='System.ComponentModel.IgnoreValueAttribute'/> class using a <see cref='System.String'/>.</para>
        /// </devdoc>
        public IgnoreValueAttribute(string value)
        {
            this.value = value;
        }

        /// <devdoc>
        /// <para>Initializes a new instance of the <see cref='System.ComponentModel.IgnoreValueAttribute'/>
        /// class.</para>
        /// </devdoc>
        public IgnoreValueAttribute(object value)
        {
            this.value = value;
        }

        /// <devdoc>
        ///    <para>
        ///       Gets the default value of the property this
        ///       attribute is
        ///       bound to.
        ///    </para>
        /// </devdoc>
        public virtual object Value
        {
            get
            {
                return value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            IgnoreValueAttribute other = obj as IgnoreValueAttribute;

            if (other != null)
            {
                if (Value != null)
                {
                    return Value.Equals(other.Value);
                }
                else
                {
                    return (other.Value == null);
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        protected void SetValue(object value)
        {
            this.value = value;
        }
    }
}
