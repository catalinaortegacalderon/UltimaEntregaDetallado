using System.Collections;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;
using ConsoleApp1.SkillsManagement.Skills.HybridSkills;

namespace ConsoleApp1.EncapsulatedLists;

public class SkillsList : IEnumerable<Skill>
{
    private readonly List<Skill> _skills = new() { new EmptySkill(), new EmptySkill(), new EmptySkill() };

    public IEnumerator<Skill> GetEnumerator()
    {
        foreach (var skill in _skills) yield return skill;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _skills.GetEnumerator();
    }

    public Skill GetSkillByIndex(int index)
    {
        return _skills[index];
    }

    public void AddSkill(int index, Skill skill)
    {
        _skills[index] = skill;
    }
}