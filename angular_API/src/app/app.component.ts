import { Component , OnInit} from '@angular/core';
import { DeveloperService} from '../app/services/developer.service'
import { Developer} from '../app/models/developer'
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  dev = {} as Developer;
  developers: Developer[] = [];


  constructor(private devService: DeveloperService) {}

  ngOnInit(): void {
    this.getDevelopers();
  }



  createDeveloper(form: NgForm) {
    if (this.dev.id !== undefined) {
      this.devService.updateDeveloper(this.dev).subscribe(() => {
        alert("Desenvolvedor atualizado com sucesso!")
        this.cleanForm(form);
      });
    } else {

      let hoje = new Date();
      let dia = hoje.getDate();
      let mes = (hoje.getMonth() + 1);
      let ano = hoje.getFullYear();
      let horas = hoje.getHours();
      let minutos = hoje.getMinutes();
      let segundos = hoje.getSeconds();
      let mseg    = hoje.getMilliseconds();
      let current_date = ano + "-" + mes + "-" + dia + "T" + horas + ":" + minutos + ":" + segundos + "." + mseg + "Z"

      this.dev.createdAt = current_date;
      

      this.devService.createDeveloper(this.dev).subscribe(() => { 
        alert("Desenvolvedor inserido com sucesso!")
        this.cleanForm(form);
     });
    }
  }

  getDevelopers() {
    this.devService.getDevelopers().subscribe((developers: Developer[]) => {
      this.developers = developers;
    });
  }

  
  deleteDeveloper(developer: Developer) {
    this.devService.deleteDeveloper(developer).subscribe(() => {
      alert("Desenvolvedor excluido com sucesso!")
      this.getDevelopers();
    });
  }

  editDeveloper(developer: Developer) {
    this.dev = { ...developer };
  }

  cleanForm(form: NgForm) {
    this.getDevelopers();
    form.resetForm();
    this.dev = {} as Developer;
  }

}
