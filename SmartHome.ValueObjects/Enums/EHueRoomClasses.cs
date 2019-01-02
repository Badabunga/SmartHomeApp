using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartHome.ValueObjects.Enums
{
    public enum EHueRoomClasses
    {
        Undefined,
        [Display(Name ="Living room")]
        Living_Room,
        [Display(Name ="Kitchen")]
        Kitchen,
        [Display(Name ="Dining")]
        Dining,
        [Display(Name ="Bedroom")]
        Bedroom,
        [Display(Name ="Kids bedroom")]
        Kids_Bedroom,
        [Display(Name ="Bathroom")]
        Bathroom,
        [Display(Name ="Nursery")]
        Nursery,
        [Display(Name ="Recreation")]
        Recreation, 
        [Display(Name ="Office")]
        Office,
        [Display(Name ="Gym")]
        Gym,
        [Display(Name ="Hallway")]
        Hallway,
        [Display(Name ="Toilet")]
        Toilet,
        [Display(Name ="Front door")]
        Front_door,
        [Display(Name ="Garage")]
        Garage,
        [Display(Name ="Terrace")]
        Terrace,
        [Display(Name ="Garden")]
        Garden,
        [Display(Name ="Driveway")]
        Driveway,
        [Display(Name = "Carport")]
        Carport,
        [Display(Name = "Other")]
        Other
    }
}
