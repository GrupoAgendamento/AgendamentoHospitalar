import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EspecialidadesCadastrarComponent } from './especialidades-cadastrar.component';

describe('EspecialidadesCadastrarComponent', () => {
  let component: EspecialidadesCadastrarComponent;
  let fixture: ComponentFixture<EspecialidadesCadastrarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EspecialidadesCadastrarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EspecialidadesCadastrarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
