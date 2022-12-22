import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EspecialidadesEditarComponent } from './especialidades-editar.component';

describe('EspecialidadesEditarComponent', () => {
  let component: EspecialidadesEditarComponent;
  let fixture: ComponentFixture<EspecialidadesEditarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EspecialidadesEditarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EspecialidadesEditarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
