import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { UserService } from '../../services/user.service';
import { NoteService } from '../../services/NoteService/note.service';
import * as jwt_decode from 'jwt-decode';
@Component({
  selector: 'app-mainnote',
  templateUrl: './mainnote.component.html',
  styleUrls: ['./mainnote.component.css']
})
export class MainnoteComponent implements OnInit {
  notes: any;
 id: string;
 @Output() public setNotes=new EventEmitter();
 UserId=localStorage.getItem('token');
  constructor(private service:NoteService) { 
    var UserID = localStorage.getItem("UserId");
    console.log(UserID);
  }
 
  ngOnInit() {
    
    this.getAllNotes();
  }

  getAllNotes(){
    var UserId=localStorage.getItem("UserId");
    this.service.getNotesById(UserId).subscribe(
      data => {
        this.notes = data;
        this.setNotes.emit(this.getAllNotes);
      }
    ), (err: any) => {
      console.log(err);
   };
  }
  closed(event){
    console.log('event');
     this.getAllNotes();
    }
}