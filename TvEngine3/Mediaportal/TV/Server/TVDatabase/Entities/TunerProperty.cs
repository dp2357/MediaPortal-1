//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace Mediaportal.TV.Server.TVDatabase.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Tuner))]
    public partial class TunerProperty: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int IdTunerProperty
        {
            get { return _idTunerProperty; }
            set
            {
                if (_idTunerProperty != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'IdTunerProperty' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _idTunerProperty = value;
                    OnPropertyChanged("IdTunerProperty");
                }
            }
        }
        private int _idTunerProperty;
    
        [DataMember]
        public int PropertyId
        {
            get { return _propertyId; }
            set
            {
                if (_propertyId != value)
                {
                    _propertyId = value;
                    OnPropertyChanged("PropertyId");
                }
            }
        }
        private int _propertyId;
    
        [DataMember]
        public int Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged("Value");
                }
            }
        }
        private int _value;
    
        [DataMember]
        public int Default
        {
            get { return _default; }
            set
            {
                if (_default != value)
                {
                    _default = value;
                    OnPropertyChanged("Default");
                }
            }
        }
        private int _default;
    
        [DataMember]
        public int Minimum
        {
            get { return _minimum; }
            set
            {
                if (_minimum != value)
                {
                    _minimum = value;
                    OnPropertyChanged("Minimum");
                }
            }
        }
        private int _minimum;
    
        [DataMember]
        public int Maximum
        {
            get { return _maximum; }
            set
            {
                if (_maximum != value)
                {
                    _maximum = value;
                    OnPropertyChanged("Maximum");
                }
            }
        }
        private int _maximum;
    
        [DataMember]
        public int Step
        {
            get { return _step; }
            set
            {
                if (_step != value)
                {
                    _step = value;
                    OnPropertyChanged("Step");
                }
            }
        }
        private int _step;
    
        [DataMember]
        public int PossibleValueFlags
        {
            get { return _possibleValueFlags; }
            set
            {
                if (_possibleValueFlags != value)
                {
                    _possibleValueFlags = value;
                    OnPropertyChanged("PossibleValueFlags");
                }
            }
        }
        private int _possibleValueFlags;
    
        [DataMember]
        public int ValueFlags
        {
            get { return _valueFlags; }
            set
            {
                if (_valueFlags != value)
                {
                    _valueFlags = value;
                    OnPropertyChanged("ValueFlags");
                }
            }
        }
        private int _valueFlags;
    
        [DataMember]
        public int IdTuner
        {
            get { return _idTuner; }
            set
            {
                if (_idTuner != value)
                {
                    ChangeTracker.RecordOriginalValue("IdTuner", _idTuner);
                    if (!IsDeserializing)
                    {
                        if (Tuner != null && Tuner.IdTuner != value)
                        {
                            Tuner = null;
                        }
                    }
                    _idTuner = value;
                    OnPropertyChanged("IdTuner");
                }
            }
        }
        private int _idTuner;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public Tuner Tuner
        {
            get { return _tuner; }
            set
            {
                if (!ReferenceEquals(_tuner, value))
                {
                    var previousValue = _tuner;
                    _tuner = value;
                    FixupTuner(previousValue);
                    OnNavigationPropertyChanged("Tuner");
                }
            }
        }
        private Tuner _tuner;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        // This entity type is the dependent end in at least one association that performs cascade deletes.
        // This event handler will process notifications that occur when the principal end is deleted.
        internal void HandleCascadeDelete(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                this.MarkAsDeleted();
            }
        }
    
        protected virtual void ClearNavigationProperties()
        {
            Tuner = null;
        }

        #endregion
        #region Association Fixup
    
        private void FixupTuner(Tuner previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.TunerProperties.Contains(this))
            {
                previousValue.TunerProperties.Remove(this);
            }
    
            if (Tuner != null)
            {
                if (!Tuner.TunerProperties.Contains(this))
                {
                    Tuner.TunerProperties.Add(this);
                }
    
                IdTuner = Tuner.IdTuner;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Tuner")
                    && (ChangeTracker.OriginalValues["Tuner"] == Tuner))
                {
                    ChangeTracker.OriginalValues.Remove("Tuner");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Tuner", previousValue);
                }
                if (Tuner != null && !Tuner.ChangeTracker.ChangeTrackingEnabled)
                {
                    Tuner.StartTracking();
                }
            }
        }

        #endregion
    }
}
