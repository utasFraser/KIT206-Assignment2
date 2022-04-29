using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KIT206_Assignment2
{
    class ConsultationList
    {
        private List<Consultation> _consultations;
        public List<Consultation> Consultations { get { return _consultations; } set { } }

        private ObservableCollection<Consultation> viewableConsultations;
        public ObservableCollection<Consultation> VisibleConsultations { get { return viewableConsultations; } set { } }

        public ConsultationList()
        {
            _consultations = sqlConn.LoadAllConsultations();
            viewableConsultations = new ObservableCollection<Consultation>(_consultations);
        }
    }
}
