import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LojaCadastrarComponent } from './loja-cadastrar.component';

describe('LojaCadastrarComponent', () => {
  let component: LojaCadastrarComponent;
  let fixture: ComponentFixture<LojaCadastrarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LojaCadastrarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LojaCadastrarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
