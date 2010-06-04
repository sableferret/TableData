using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Linq.Expressions;

namespace NickField.TableDrivenData.Lib
{
    /// <summary>
    /// Foundation class for notifying property updates
    /// </summary>
    public abstract class BaseNotifier : INotifyPropertyChanged
    {
        #region Instance Members and Constants
        public const string IS_DIRTY = "IsDirty";
        public const string IGNORE_DIRTY = "IgnoreDirty";

        private bool _isDirty = false;
        #endregion

        #region Constructor
        protected BaseNotifier()
        {
            PropertyChanged += BaseNotifier_PropertyChanged;
        }
        #endregion

        void BaseNotifier_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!_isDirty && !e.PropertyName.Equals(IS_DIRTY))
                IsDirty = true;
        }

        public bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                if (!_isDirty.Equals(value))
                {
                    _isDirty = value;
                    RaisePropertyChanged(() => IsDirty);
                }
            }
        }

        public void NotifyOfPropertyChange(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RaisePropertyChanged<TProperty>(Expression<Func<TProperty>> property)
        {
            if (PropertyChanged != null)
            {
                var lambda = (LambdaExpression)property;

                MemberExpression memberExpression;

                if (lambda.Body is UnaryExpression)
                {
                    var unaryExpression = (UnaryExpression)lambda.Body;
                    memberExpression = (MemberExpression)unaryExpression.Operand;
                }
                else memberExpression = (MemberExpression)lambda.Body;

                NotifyOfPropertyChange(memberExpression.Member.Name);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
