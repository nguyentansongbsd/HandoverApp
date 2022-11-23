using HandoverApp.Helpers;
using HandoverApp.Models;
using HandoverApp.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HandoverApp.ViewModels
{
    public class FloorPlanPageViewModel : BaseViewModel
    {
        private Unit _unit;
        public Unit Unit { get => _unit; set { _unit = value; OnPropertyChanged(nameof(Unit)); } }

        private ObservableCollection<QueueListModel> _queueList;
        public ObservableCollection<QueueListModel> QueueList { get => _queueList; set { _queueList = value; OnPropertyChanged(nameof(QueueList)); } }

        public int PageDanhSachDatCho = 1;

        private bool _showMoreDanhSachDatCho;
        public bool ShowMoreDanhSachDatCho { get => _showMoreDanhSachDatCho; set { _showMoreDanhSachDatCho = value; OnPropertyChanged(nameof(ShowMoreDanhSachDatCho)); } }

        private string _unitView;
        public string UnitView { get => _unitView; set { _unitView = value; OnPropertyChanged(nameof(UnitView)); } }

        private string _unitID;
        public string UnitID { get => _unitID; set { _unitID = value; OnPropertyChanged(nameof(UnitID)); LoadUnitById(UnitID); } }

        public FloorPlanPageViewModel()
        {
            QueueList = new ObservableCollection<QueueListModel>();
        }

        public async Task LoadUnitById(string unitId)
        {
            string fetchXml = $@"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                  <entity name='product'>
                                    <attribute name='name' />
                                    <attribute name='statuscode' />
                                    <attribute name='bsd_projectcode' alias='_bsd_projectcode_value'/>
                                    <attribute name='price' />
                                    <attribute name='productid' />
                                    <attribute name='bsd_viewphulong' />
                                    <attribute name='bsd_direction' />
                                    <attribute name='bsd_constructionarea' />
                                    <attribute name='bsd_netsaleablearea' />
                                    <attribute name='bsd_floor' alias='floorid'/>
                                    <attribute name='bsd_blocknumber' alias='blockid'/>
                                    <attribute name='bsd_phaseslaunchid' alias='_bsd_phaseslaunchid_value' />
                                    <attribute name='bsd_vippriority' />
                                    <order attribute='bsd_constructionarea' descending='true' />
                                    <filter type='and'>
                                      <condition attribute='productid' operator='eq' uitype='product' value='{unitId}' />
                                    </filter>
                                    <link-entity name='bsd_unittype' from='bsd_unittypeid' to='bsd_unittype' visible='false' link-type='outer' alias='a_493690ec6ce2e811a94e000d3a1bc2d1'>
                                      <attribute name='bsd_name'  alias='bsd_unittype_name'/>
                                    </link-entity>
                                    <link-entity name='bsd_phaseslaunch' from='bsd_phaseslaunchid' to='bsd_phaseslaunchid' link-type='outer' alias='ac'>
                                      <link-entity name='bsd_event' from='bsd_phaselaunch' to='bsd_phaseslaunchid' link-type='outer' alias='ad'>
                                        <attribute name='bsd_eventid' alias='event_id' />
                                        <filter type='and'>
                                            <condition attribute='statuscode' operator='eq' value='100000000' />
                                            <condition attribute='bsd_eventid' operator='not-null' />
                                        </filter>
                                      </link-entity>
                                    </link-entity>
                                  </entity>
                                </fetch>";
            var result = await CrmHelper.RetrieveMultiple<RetrieveMultipleApiResponse<Unit>>("products", fetchXml);
            if (result == null || result.value.Any() == false) return;
            Unit = result.value.FirstOrDefault();
        }
        public async Task LoadQueues(string unitId)
        {
            string fetch = $@"<fetch version='1.0' count='5' page='{PageDanhSachDatCho}' output-format='xml-platform' mapping='logical' distinct='false'>
                      <entity name='opportunity'>
                        <attribute name='name'/>
                        <attribute name='statuscode' />
                        <attribute name='bsd_project' />
                        <attribute name='opportunityid' />
                        <attribute name='bsd_queuingfeepaid' />
                        <attribute name='bsd_collectedqueuingfee' />
                        <attribute name='bsd_queuingexpired' />
                        <attribute name='bsd_queuenumber' />
                        <attribute name='bsd_queueforproject' />
                        <order attribute='statuscode' descending='false' />
                        <filter type='and'>
                            <condition attribute='bsd_units' operator='eq' value='{unitId}'/>
                            <condition attribute='{UserLogged.UserAttribute}' operator='eq' value='{UserLogged.Id}'/>
                            <condition attribute='statuscode' operator='in'>
                                <value>100000002</value>
                                <value>100000000</value>
                            </condition>
                        </filter>
                        <link-entity name='bsd_project' from='bsd_projectid' to='bsd_project' visible='false' link-type='outer' alias='a_edc3f143ba81e911a83b000d3a07be23'>
                            <attribute name='bsd_name' alias='project_name'/>
                        </link-entity>
                        <link-entity name='account' from='accountid' to='parentaccountid' visible='false' link-type='outer' alias='a_87ea9a00777ee911a83b000d3a07fbb4'>
                            <attribute name='name' alias='account_name'/>
                        </link-entity>
                        <link-entity name='contact' from='contactid' to='parentcontactid' visible='false' link-type='outer' alias='a_8eea9a00777ee911a83b000d3a07fbb4'>
                            <attribute name='bsd_fullname' alias='contact_name'/>
                        </link-entity>
                      </entity>
                    </fetch>";

            var result = await CrmHelper.RetrieveMultiple<RetrieveMultipleApiResponse<QueueListModel>>("opportunities", fetch);
            if (result == null || result.value.Any() == false) return;
            var data = result.value;
            ShowMoreDanhSachDatCho = data.Count < 5 ? false : true;
            foreach (var item in data)
            {
                QueueList.Add(item);
            }
        }
    }
}
