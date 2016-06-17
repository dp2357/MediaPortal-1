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
    [KnownType(typeof(TunerSatellite))]
    public partial class LnbType: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int IdLnbType
        {
            get { return _idLnbType; }
            set
            {
                if (_idLnbType != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'IdLnbType' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _idLnbType = value;
                    OnPropertyChanged("IdLnbType");
                }
            }
        }
        private int _idLnbType;
    
        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string _name;
    
        [DataMember]
        public int LowBandFrequency
        {
            get { return _lowBandFrequency; }
            set
            {
                if (_lowBandFrequency != value)
                {
                    _lowBandFrequency = value;
                    OnPropertyChanged("LowBandFrequency");
                }
            }
        }
        private int _lowBandFrequency;
    
        [DataMember]
        public int HighBandFrequency
        {
            get { return _highBandFrequency; }
            set
            {
                if (_highBandFrequency != value)
                {
                    _highBandFrequency = value;
                    OnPropertyChanged("HighBandFrequency");
                }
            }
        }
        private int _highBandFrequency;
    
        [DataMember]
        public int SwitchFrequency
        {
            get { return _switchFrequency; }
            set
            {
                if (_switchFrequency != value)
                {
                    _switchFrequency = value;
                    OnPropertyChanged("SwitchFrequency");
                }
            }
        }
        private int _switchFrequency;
    
        [DataMember]
        public bool IsBandStacked
        {
            get { return _isBandStacked; }
            set
            {
                if (_isBandStacked != value)
                {
                    _isBandStacked = value;
                    OnPropertyChanged("IsBandStacked");
                }
            }
        }
        private bool _isBandStacked;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<TunerSatellite> TunerSatellites
        {
            get
            {
                if (_tunerSatellites == null)
                {
                    _tunerSatellites = new TrackableCollection<TunerSatellite>();
                    _tunerSatellites.CollectionChanged += FixupTunerSatellites;
                }
                return _tunerSatellites;
            }
            set
            {
                if (!ReferenceEquals(_tunerSatellites, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_tunerSatellites != null)
                    {
                        _tunerSatellites.CollectionChanged -= FixupTunerSatellites;
                    }
                    _tunerSatellites = value;
                    if (_tunerSatellites != null)
                    {
                        _tunerSatellites.CollectionChanged += FixupTunerSatellites;
                    }
                    OnNavigationPropertyChanged("TunerSatellites");
                }
            }
        }
        private TrackableCollection<TunerSatellite> _tunerSatellites;

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
    
        protected virtual void ClearNavigationProperties()
        {
            TunerSatellites.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupTunerSatellites(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (TunerSatellite item in e.NewItems)
                {
                    item.LnbType = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("TunerSatellites", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (TunerSatellite item in e.OldItems)
                {
                    if (ReferenceEquals(item.LnbType, this))
                    {
                        item.LnbType = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("TunerSatellites", item);
                    }
                }
            }
        }

        #endregion
    }
}
