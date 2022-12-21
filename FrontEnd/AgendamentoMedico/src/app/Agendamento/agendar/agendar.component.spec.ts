import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgendamentoCadastrarComponent } from './agendar.component';

describe('AgendarComponent', () => {
  let component: AgendamentoCadastrarComponent;
  let fixture: ComponentFixture<AgendamentoCadastrarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AgendamentoCadastrarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AgendamentoCadastrarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
