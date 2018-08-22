using System.Collections.Generic;
using CommunityParkletDashboard.DTOs;
using CommunityParkletDashboard.Models;
using PagedList;

namespace CommunityParkletDashboard.ViewModels
{
    public class CPEmailDashboardModel
    {
        public IPagedList<ParkletApplicationEmailDTO> lParkletApplicationEmailDtos { get; set; }

        public CPEmailDashboardModel(List<COMMUNITY_PARKLET_APPLICATION_EMAIL> lApplications, int? page)
        {
            var tempList = new List<ParkletApplicationEmailDTO>();

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
                    tempList.Add(applicationDTO);
                }

                lParkletApplicationEmailDtos = tempList.ToPagedList(page ?? 1, 15);
            }
        }
    }
}