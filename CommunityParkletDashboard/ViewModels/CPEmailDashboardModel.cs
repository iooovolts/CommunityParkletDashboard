using System.Collections.Generic;
using CommunityParkletDashboard.DTOs;
using CommunityParkletDashboard.Models;

namespace CommunityParkletDashboard.ViewModels
{
    public class CPEmailDashboardModel
    {
        public CPEmailDashboardModel(List<COMMUNITY_PARKLET_APPLICATION_EMAIL> lApplications)
        {
            lParkletApplicationEmailDtos = new List<ParkletApplicationEmailDTO>();

            if (lApplications != null)
            {
                foreach (COMMUNITY_PARKLET_APPLICATION_EMAIL application in lApplications)
                {
                    ParkletApplicationEmailDTO applicationDTO = new ParkletApplicationEmailDTO()
                    {
                        Id = application.ID,
                        Name = application.NAME,
                        EmailAddress = application.EMAIL_ADDRESS
                    };
                    lParkletApplicationEmailDtos.Add(applicationDTO);
                }
            }
        }
        public List<ParkletApplicationEmailDTO> lParkletApplicationEmailDtos { get; set; }
    }
}