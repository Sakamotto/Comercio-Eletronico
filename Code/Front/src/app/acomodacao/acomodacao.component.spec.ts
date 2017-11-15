import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AcomodacaoComponent } from './acomodacao.component';

describe('AcomodacaoComponent', () => {
  let component: AcomodacaoComponent;
  let fixture: ComponentFixture<AcomodacaoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AcomodacaoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AcomodacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
