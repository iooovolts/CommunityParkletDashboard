using System.Collections.Generic;
using CommunityParkletDashboard.DTOs;
using CommunityParkletDashboard.Models;

namespace CommunityParkletDashboard.ViewModels
{
    public class CPDashboardModel
    {
        public CPDashboardModel(List<COMMUNITY_PARKLET_APPLICATION> lApplications)
        {
            lParkletApplicationDtos = new List<ParkletApplicationDTO>();

            if (lApplications != null)
            {
                foreach (COMMUNITY_PARKLET_APPLICATION application in lApplications)
                {
                    ParkletApplicationDTO applicationDTO = new ParkletApplicationDTO
                    {
                        RefNumber = application.REF_NUMBER,
                        Name = application.NAME,
                        Parklet24hrContact = application.PARKLET_24HR_CONTACT,
                        ParkletDescription = application.PARKLET_DESCRIPTION,
                        ParkletTimeFrame = application.PARKLET_TIME_FRAME,
                        ParkletTitle = application.PARKLET_TITLE,
                        Phone = application.PHONE,
                        Notes = application.NOTES,
                        Status = application.STATUS,
                        FileName = application.FILE_NAME
                    };
                    string type = application.TYPE_DISPLAY + "\n" + application.TYPE_EDUCATIONAL + "\n" +
                                  application.TYPE_FITNESS + "\n" + application.TYPE_GARDEN + "\n" +
                                  application.OTHER + "\n" + application.TYPE_PLAY_AREA + "\n" +
                                  application.TYPE_REST_AREA;
                    applicationDTO.Type = type;

                    string address = application.C_ADDRESS_WITH_MANUAL_FIELDS__AREA + "\n" +
                                     application.C_ADDRESS_WITH_MANUAL_FIELDS__PREMISES_NO + "\n" +
                                     application.C_ADDRESS_WITH_MANUAL_FIELDS__STREET_NAME + "\n" +
                                     application.C_ADDRESS_WITH_MANUAL_FIELDS__POSTCODE;
                    applicationDTO.Address = address;

                    string parkletAddress = application.PARKLET__ADDRESS_NAME + "\n" + application.PARKLET__LINE1 + "\n" + application.PARKLET__LINE2 + "\n" +
                                     application.PARKLET__LINE3 + "\n" + application.PARKLET__POSTCODE; ;
                    applicationDTO.ParkletAddress = parkletAddress;

                    lParkletApplicationDtos.Add(applicationDTO);
                }
            }
        }

        public CPDashboardModel(COMMUNITY_PARKLET_APPLICATION lApplications)
        {
            lParkletApplicationDtos = new List<ParkletApplicationDTO>();

            if (lApplications != null)
            {
              
                    ParkletApplicationDTO applicationDTO = new ParkletApplicationDTO
                    {
                        RefNumber = lApplications.REF_NUMBER,
                        Name = lApplications.NAME,
                        Parklet24hrContact = lApplications.PARKLET_24HR_CONTACT,
                        ParkletDescription = lApplications.PARKLET_DESCRIPTION,
                        ParkletTimeFrame = lApplications.PARKLET_TIME_FRAME,
                        ParkletTitle = lApplications.PARKLET_TITLE,
                        Phone = lApplications.PHONE,
                        Notes = lApplications.NOTES,
                        Status = lApplications.STATUS,
                    };
                    string type = lApplications.TYPE_DISPLAY + "\n" + lApplications.TYPE_EDUCATIONAL + "\n" +
                                  lApplications.TYPE_FITNESS + "\n" + lApplications.TYPE_GARDEN + "\n" +
                                  lApplications.OTHER + "\n" + lApplications.TYPE_PLAY_AREA + "\n" +
                                  lApplications.TYPE_REST_AREA;
                    applicationDTO.Type = type;

                string address = lApplications.C_ADDRESS_WITH_MANUAL_FIELDS__AREA + "\n" +
                                 lApplications.C_ADDRESS_WITH_MANUAL_FIELDS__PREMISES_NO + "\n" +
                                 lApplications.C_ADDRESS_WITH_MANUAL_FIELDS__STREET_NAME + "\n" +
                                 lApplications.C_ADDRESS_WITH_MANUAL_FIELDS__POSTCODE;
                    applicationDTO.Address = address;

                    string parkletAddress = lApplications.PARKLET__ADDRESS_NAME + "\n" + lApplications.PARKLET__LINE1 + "\n" + lApplications.PARKLET__LINE2 + "\n" +
                                     lApplications.PARKLET__LINE3 + "\n" + lApplications.PARKLET__POSTCODE;
                applicationDTO.ParkletAddress = parkletAddress;

                    lParkletApplicationDtos.Add(applicationDTO);
              
            }
        }

        public List<ParkletApplicationDTO> lParkletApplicationDtos { get; set; }
    }
}