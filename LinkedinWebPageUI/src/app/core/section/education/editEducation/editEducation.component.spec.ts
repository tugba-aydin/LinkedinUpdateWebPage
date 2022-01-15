/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { EditEducationComponent } from './editEducation.component';

describe('EditEducationComponent', () => {
  let component: EditEducationComponent;
  let fixture: ComponentFixture<EditEducationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditEducationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditEducationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
