export class Reservation{
    Id:string;
    UserId:string
    ApartmentId:string
    Host:string;
    Guest:string;
    StartingDate:string;
    OvernightStaysNum:string;
    TotalPrice:number;
    Status:string;
    ReservationDate:Date;
    
    constructor(id:string,host:string, guest:string, startingDate:string, overnightStaysNum:string, totalPrice:number, status:string)
    {
        this.Id=id;
        this.Host=host;
        this.Guest=guest;
        this.StartingDate=startingDate;
        this.OvernightStaysNum=overnightStaysNum;
        this.TotalPrice=totalPrice;
        this.Status=status;
    }
}