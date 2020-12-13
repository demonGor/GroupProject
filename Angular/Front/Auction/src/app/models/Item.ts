export class Item
{
    Id:number;
    Title:string;
    Description:string;
    StartingPrice:number;
    MinIncrease:number;
    StartTime:Date;
    EndTime:Date;
    CategoryId:number;
    CategoryName?:string;
    Image?:string;
    UserId:number;
    UserName?:string;
}