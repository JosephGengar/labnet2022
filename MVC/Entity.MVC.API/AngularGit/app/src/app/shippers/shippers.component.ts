import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ApishippersService } from '../services/apishippers.service';
import { DialogShipperComponent } from './dialog/dialogShipper.component';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTable, MatTableDataSource} from '@angular/material/table';
import { Shipper } from '../models/shipperView';
import { MatSnackBar } from '@angular/material/snack-bar';
import { dialogDeleteComponent } from '../common/delete/dialog.delete.component';

@Component({
  selector: 'app-shippers',
  templateUrl: './shippers.component.html',
  styleUrls: ['./shippers.component.scss']
})
export class ShippersComponent implements OnInit {
  displayedColumns: string[] = ['ShipperID', 'CompanyName', 'PhoneNumber', 'Actions'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  public lst: any[] = [];

  constructor(private apiShippers: ApishippersService,
              public dialog: MatDialog,
              public snackbar : MatSnackBar) { 

  }
  ngOnInit(): void {
    this.getShippersC();
  }
  getShippersC(){
    this.apiShippers.getClientes().subscribe({
      next:(response) => {
        this.lst = response.data;
        this.dataSource = new MatTableDataSource(response.data);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error:(err) => {
        alert("Error!!! while fetching the records!!!");
      }
    })
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  openNew(){
    const dialgoREF = this.dialog.open(DialogShipperComponent, {
      width : '400px',     
    });
    dialgoREF.afterClosed().subscribe(result => {
      this.getShippersC();
    });
  }
  openEdit(shipper : Shipper){
    const dialogREF = this.dialog.open(DialogShipperComponent, {
      width: '400px',
      data: shipper
    });
    dialogREF.afterClosed().subscribe(result => {
      this.getShippersC();
    });
  }
  openDelete(shipper : Shipper){
    const dialgoREF = this.dialog.open(dialogDeleteComponent, {
      width: '380px',
      height: '250px'
    });
    dialgoREF.afterClosed().subscribe(result => {
      if(result){
        this.apiShippers.deleteShipper(shipper.ShipperID).subscribe({
          next: (response) => {
            if(response.sucess ==1){
              this.getShippersC();
              this.snackbar.open(response.message, '', {duration:3500})
            }
          },
          error: (err) => {
            alert('Error!!! We have a problem with the operation');
          }      
        })
      }
    })
  }
}
