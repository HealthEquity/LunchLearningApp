﻿using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LunchAndLearnMobile.Behaviors
{
  public class StarBehavior : Behavior<View>
  {
    TapGestureRecognizer tapRecognizer;
    static List<StarBehavior> defaultBehaviors = new List<StarBehavior>();
    static Dictionary<string, List<StarBehavior>> starGroups = new Dictionary<string, List<StarBehavior>>();

    public static readonly BindableProperty GroupNameProperty =
        BindableProperty.Create("GroupName",
                                typeof(string),
                                typeof(StarBehavior),
                                null,
                                propertyChanged: OnGroupNameChanged);

    public string GroupName
    {
      set { SetValue(GroupNameProperty, value); }
      get { return (string)GetValue(GroupNameProperty); }
    }

    public static readonly BindableProperty RatingProperty =
       BindableProperty.Create("Rating",
                               typeof(int),
                               typeof(StarBehavior), default(int));

    public int Rating
    {
      set { SetValue(RatingProperty, value); }
      get { return (int)GetValue(RatingProperty); }
    }

    static void OnGroupNameChanged(BindableObject bindable, object oldValue, object newValue)
    {
      StarBehavior behavior = (StarBehavior)bindable;
      string oldGroupName = (string)oldValue;
      string newGroupName = (string)newValue;

      // Remove existing behavior from Group
      if (String.IsNullOrEmpty(oldGroupName))
      {
        defaultBehaviors.Remove(behavior);
      }
      else
      {
        List<StarBehavior> behaviors = starGroups[oldGroupName];
        behaviors.Remove(behavior);

        if (behaviors.Count == 0)
        {
          starGroups.Remove(oldGroupName);
        }
      }

      // Add New Behavior to the group
      if (String.IsNullOrEmpty(newGroupName))
      {
        defaultBehaviors.Add(behavior);
      }
      else
      {
        List<StarBehavior> behaviors = null;

        if (starGroups.ContainsKey(newGroupName))
        {
          behaviors = starGroups[newGroupName];
        }
        else
        {
          behaviors = new List<StarBehavior>();
          starGroups.Add(newGroupName, behaviors);
        }

        behaviors.Add(behavior);
      }

    }


    public static readonly BindableProperty IsStarredProperty =
        BindableProperty.Create("IsStarred",
                                typeof(bool),
                                typeof(StarBehavior),
                                false,
                                propertyChanged: OnIsStarredChanged);

    public bool IsStarred
    {
      set { SetValue(IsStarredProperty, value); }
      get { return (bool)GetValue(IsStarredProperty); }
    }

    static void OnIsStarredChanged(BindableObject bindable, object oldValue, object newValue)
    {
      StarBehavior behavior = (StarBehavior)bindable;

      if ((bool)newValue)
      {
        string groupName = behavior.GroupName;
        List<StarBehavior> behaviors = null;

        if (string.IsNullOrEmpty(groupName))
        {
          behaviors = defaultBehaviors;
        }
        else
        {
          behaviors = starGroups[groupName];
        }

        bool itemReached = false;
        int count = 1, position = 0;
        // all positions to left IsStarred = true and all position to the right is false
        foreach (var item in behaviors)
        {
          if (item != behavior && !itemReached)
          {
            item.IsStarred = true;
          }
          if (item == behavior)
          {
            itemReached = true;
            item.IsStarred = true;
            position = count;
          }
          if (item != behavior && itemReached)
            item.IsStarred = false;

          item.Rating = position;
          count++;
        }

      }


    }

    public StarBehavior()
    {
      defaultBehaviors.Add(this);
    }

    protected override void OnAttachedTo(View view)
    {
      tapRecognizer = new TapGestureRecognizer();
      tapRecognizer.Tapped += OnTapRecognizerTapped;
      view.GestureRecognizers.Add(tapRecognizer);
    }

    protected override void OnDetachingFrom(View view)
    {
      view.GestureRecognizers.Remove(tapRecognizer);
      tapRecognizer.Tapped -= OnTapRecognizerTapped;
    }

    void OnTapRecognizerTapped(object sender, EventArgs args)
    {
      IsStarred = false;
      IsStarred = true;
    }
  }
}